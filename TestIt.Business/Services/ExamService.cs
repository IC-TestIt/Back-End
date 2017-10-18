using System;
using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IAnsweredQuestionRepository _answeredQuestionRepository;


        public ExamService(IExamRepository examRepository, IAnsweredQuestionRepository answeredQuestionRepository)
        {
            _examRepository = examRepository;
            _answeredQuestionRepository = answeredQuestionRepository;
        }

        public void Save(Exam e)
        {
            _examRepository.Add(e);
            _examRepository.Commit();
        }
        public IEnumerable<ExamDto> GetStudentExams(int id)
        {
            var exams = _examRepository.GetExams(id);
            return exams;
        }

        public bool EndExam(int id, List<AnsweredQuestion> answerdQuestions)
        {
            var e = _examRepository.GetSingle(id);

            if (e == null) return false;
            e.DateUpdated = DateTime.Now;
            e.Status = (int)EnumStatus.Finished;
            e.EndDate = DateTime.Now;

            _answeredQuestionRepository.AddOrUpdateMultiple(answerdQuestions);

            _examRepository.Commit();

            return true;
        }

        public bool SaveExam(int id, List<AnsweredQuestion> answerdQuestions)
        {
            var e = _examRepository.GetSingle(id);

            if (e == null) return false;
            e.DateUpdated = DateTime.Now;

            _answeredQuestionRepository.AddOrUpdateMultiple(answerdQuestions);

            _examRepository.Commit();

            return true;
        }

        public ExamInformationsDto Get (int id)
        {
            var exam = _examRepository.GetFull(id);
            
            return exam;
        }

        public bool ExistsExam(Exam exam)
        {
            return _examRepository.Any(x => x.ClassTestsId == exam.ClassTestsId && x.StudentId == exam.StudentId);
        }
        
        public bool Correct(int id)
        {
            var fullExam = _examRepository.GetFull(id);

            if (fullExam == null)
                return false;

            var correctionManager = new CorrectionManager(fullExam);

            var correction = correctionManager.Correct();

            var exam = _examRepository.GetSingle(id);
            exam.TotalGrade = correction.TotalGrade;

            _answeredQuestionRepository.AddOrUpdateMultiple(correction.AnsweredQuestions);

            _examRepository.Commit();
            
            return true;
        }

        public IEnumerable<Exam> GetExamsCorrection(IEnumerable<int> classtests)
        {
            var exams = new List<Exam>();

            foreach (int ct in classtests)
            {
                exams.AddRange(_examRepository.FindByIncluding(x => x.ClassTestsId == ct, x => x.AnsweredQuestions));
            }

            return exams;

        }
    }
}
