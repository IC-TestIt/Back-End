using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(TestItContext context)
            : base(context)
        {
        }

        public IEnumerable<User> ClassUsers (int classId)
        {
            var users = (from a in Context.ClassStudents
                         join b in Context.Students on a.StudentId equals b.Id
                         join c in Context.Users on b.UserId equals c.Id
                         where a.ClassId == classId
                         select c).ToList();

            return users;
        }
    }
}
