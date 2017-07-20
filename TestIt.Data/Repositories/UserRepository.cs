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
        private TestItContext context;
        public UserRepository(TestItContext context)
            : base(context)
        {
            this.context = context;
        }

        public List<User> ClassUsers (int classId)
        {
            var users = (from a in context.ClassStudents
                         join b in context.Students on a.StudentId equals b.Id
                         join c in context.Users on b.UserId equals c.Id
                         where a.ClassId == classId
                         select c).ToList();

            return users;
        }
    }
}
