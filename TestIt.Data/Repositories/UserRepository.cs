using System.Collections.Generic;
using TestIt.Data;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;
using System.Linq;

namespace TestIt.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(TestItContext context)
            : base(context)
        {
        }

        public List<User> ClassUsers (int classId)
        {
            var users = (from a in _context.ClassStudents
                         join b in _context.Students on a.StudentId equals b.Id
                         join c in _context.Users on b.UserId equals c.Id
                         where a.ClassId == classId
                         select c).ToList();

            return users;
        }
    }
}
