using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class EssayQuestionRepository : EntityBaseRepository<EssayQuestion>, IEssayQuestionRepository
    {
        public EssayQuestionRepository(TestItContext context)
            : base(context)
        { }
    }
}
