using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class SocialIdRepository : EntityBaseRepository<SocialIdentifier>, ISocialIdRepository
    {
        public SocialIdRepository(TestItContext context)
            : base(context)
        { }
    }
}