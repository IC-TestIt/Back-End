using TestIt.Data.Abstract;
using TestIt.Model.Entities;
using System.Linq;
using TestIt.Model.DTO;
using System.Collections.Generic;

namespace TestIt.Data.Repositories
{
    public class ExamRepository : EntityBaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(TestItContext context)
            : base(context)
        {
        }

        public IEnumerable<ExamDTO> GetExams(int id)
        {
            var exams = (from a in _context.ClassTests
                     join b in _context.Exams on a.Id equals b.ClassTestsId
                     join c in _context.Tests on a.TestId equals c.Id
                     where b.StudentId == id
                     select new ExamDTO
                     {
                         Description = c.Description,
                         ExamId = b.Id,
                         TotalGrade = b.TotalGrade,
                         Status = b.Status,
                         Title = c.Title
                     }).ToList();

            return exams;
        }

        public ExamInformationsDTO GetFull(int id)
        {
            var exam = (from a in _context.Exams
                        join b in _context.ClassTests on a.ClassTestsId equals b.Id
                        join c in _context.Tests on b.TestId equals c.Id
                        select new ExamInformationsDTO
                        {
                            Id = a.Id,
                            BeginDate = a.BeginDate,
                            EndDate = a.EndDate,
                            Title = c.Title,
                            TestId = c.Id
                        }).FirstOrDefault();

            exam.Questions = (from a in _context.Questions
                              where a.TestId == exam.TestId
                              select a).ToList();

            exam.AnsweredQuestions = (from a in _context.AnsweredQuestions
                                      where a.ExamId == exam.Id
                                      select a).ToList();

            return exam;
        }
    }
}
