using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class AlternativeQuestionRepository : EntityBaseRepository<AlternativeQuestion>,IAlternativeQuestionRepository
    {
        public AlternativeQuestionRepository(TestItContext context)
            : base(context)
        { }
    }
}
