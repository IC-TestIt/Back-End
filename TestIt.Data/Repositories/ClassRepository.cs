using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class ClassRepository : EntityBaseRepository<Class>, IClassRepository
    {
        public ClassRepository(TestItContext context)
            : base(context)
        { }
    }
}