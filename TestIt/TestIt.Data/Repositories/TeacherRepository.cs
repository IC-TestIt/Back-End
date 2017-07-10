using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class TeacherRepository : EntityBaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(TestItContext context)
            : base(context)
        { }
    }
}
