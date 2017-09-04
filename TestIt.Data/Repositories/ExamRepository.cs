using TestIt.Data.Abstract;
using TestIt.Model.Entities;
using System.Linq;
using TestIt.Model.DTO;
using System.Collections.Generic;

namespace TestIt.Data.Repositories
{
    public class ExamRepository : EntityBaseRepository<Exam>, IExamRepository
    {
        private TestItContext context;

        public ExamRepository(TestItContext context)
            : base(context)
        {
            this.context = context;
        }

        public IEnumerable<ExamDTO> GetExams(int id)
        {
            var exams = (from a in context.ClassTests
                     join b in context.Exams on a.Id equals b.ClassTestsId
                     join c in context.Tests on a.TestId equals c.Id
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
    }
}
