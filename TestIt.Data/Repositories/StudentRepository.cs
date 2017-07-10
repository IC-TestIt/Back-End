using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(TestItContext context)
            : base(context)
        { }
    }
}