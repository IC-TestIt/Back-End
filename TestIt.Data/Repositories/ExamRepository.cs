using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class ExamRepository : EntityBaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(TestItContext context)
            : base(context)
        {
        }

        public IEnumerable<ExamDto> GetExams(int id)
        {
            var exams = (from a in Context.ClassTests
                         join b in Context.Exams on a.Id equals b.ClassTestsId
                         join c in Context.Tests on a.TestId equals c.Id
                         where b.StudentId == id
                         select new ExamDto
                         {
                             Description = c.Description,
                             ExamId = b.Id,
                             TotalGrade = b.TotalGrade,
                             Status = b.Status,
                             Title = c.Title
                         }).ToList();

            return exams;
        }

        public ExamInformationsDto GetFull(int id)
        {
            var exam = (from a in Context.Exams
                        join b in Context.ClassTests on a.ClassTestsId equals b.Id
                        join c in Context.Tests on b.TestId equals c.Id
                        where a.Id == id
                        select new ExamInformationsDto
                        {
                            Id = a.Id,
                            BeginDate = a.BeginDate,
                            EndDate = b.EndDate,
                            Title = c.Title,
                            TestId = c.Id,
                            Status = a.Status
                        }).FirstOrDefault();

            exam.Questions = (from a in Context.Questions
                              where a.TestId == exam.TestId
                              select a).Include(x => x.EssayQuestion).Include(x => x.AlternativeQuestion.Alternatives).ToList();

            exam.AnsweredQuestions = (from a in Context.AnsweredQuestions
                                      where a.ExamId == exam.Id
                                      select a).ToList();

            return exam;
        }
    }
}
