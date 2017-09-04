using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ExamService : IExamService
    {
        private IExamRepository examRepository;
        
        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        public void Save(Exam e)
        {
            examRepository.Add(e);
            examRepository.Commit();
        }
        public IEnumerable<ExamDTO> GetStudentExams(int id)
        {
            var exams = examRepository.GetExams(id);
            return exams;
        }

        public bool EndExam(int id, Exam exam)
        {
            Exam e = examRepository.GetSingle(id);

            if (e != null)
            {
                e.DateUpdated = DateTime.Now;
                e.Status = exam.Status;
                e.EndDate = DateTime.Now;

                examRepository.Commit();

                return true;
            }
            else
                return false;
        }
    }
}
