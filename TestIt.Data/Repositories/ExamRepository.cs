using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class ExamRepository : EntityBaseRepository<Exam>, IExamRepository
    {
        public ExamRepository(TestItContext context)
            : base(context)
        { }
    }
}
