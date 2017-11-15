using TestIt.Data.Abstract;
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
