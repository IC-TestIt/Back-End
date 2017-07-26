using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class TestRepository : EntityBaseRepository<Test>, ITestRepository
    {
        public TestRepository(TestItContext context)
            : base(context)
        { }
    }       
}
