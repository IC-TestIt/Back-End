using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class AlternativeRepository : EntityBaseRepository<Alternative>, IAlternativeRepository
    {
        public AlternativeRepository(TestItContext context)
            : base(context)
        { }
    }
}
