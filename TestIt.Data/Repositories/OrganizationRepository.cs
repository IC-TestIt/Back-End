using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class OrganizationRepository : EntityBaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(TestItContext context)
            : base(context)
        { }
    }
}