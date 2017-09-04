using System;
using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ExamService : IExamService
    {
        private IExamRepository _examRepository;
        private ITestRepository _testRepository;


        public ExamService(IExamRepository examRepository, ITestRepository testRepository)
        {
            _examRepository = examRepository;
            _testRepository = testRepository;
        }

        public void Save(Exam e)
        {
            _examRepository.Add(e);
            _examRepository.Commit();
        }
        public IEnumerable<ExamDTO> GetStudentExams(int id)
        {
            var exams = _examRepository.GetExams(id);
            return exams;
        }

        public bool EndExam(int id, Exam exam)
        {
            Exam e = _examRepository.GetSingle(id);

            if (e != null)
            {
                e.DateUpdated = DateTime.Now;
                e.Status = exam.Status;
                e.EndDate = DateTime.Now;

                _examRepository.Commit();

                return true;
            }
            else
                return false;
        }

        public ExamInformationsDTO Get (int id)
        {
            var exam = _examRepository.GetFull(id);
            
            return exam;
        }
    }
}
