using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

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

        public Exam GetFull(int id)
        {
            var question = (from a in context.AnsweredQuestions
                join b in context.Exams on a.ExamId equals b.Id
                where a.ExamId == id
                select a).Include(x => x.Question).Include(x => x.Exam).Include(x => x.Alternative).ToList();

            return question.FirstOrDefault().Exam ?? null;
        }
    }
}
