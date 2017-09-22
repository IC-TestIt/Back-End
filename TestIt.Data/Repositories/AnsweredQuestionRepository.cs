using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class AnsweredQuestionRepository : EntityBaseRepository<AnsweredQuestion>, IAnsweredQuestionRepository
    {
        public AnsweredQuestionRepository(TestItContext context)
            : base(context)
        { }
    }
}
