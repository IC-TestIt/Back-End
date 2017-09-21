using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class ClassTestsRepository : EntityBaseRepository<ClassTests>, IClassTestsRepository
    {
        public ClassTestsRepository(TestItContext context)
            : base(context)
        { }
    }
}
