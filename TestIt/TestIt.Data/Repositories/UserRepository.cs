using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(TestItContext context)
            : base(context)
        { }
    }
}
