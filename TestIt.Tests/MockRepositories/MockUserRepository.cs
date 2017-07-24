using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TestIt.Model.Entities;

namespace TestIt.Tests.MockRepositories
{
    public class MockUserRepository : Data.Abstract.IUserRepository
    {
        private IQueryable<User> users;
        
        public MockUserRepository()
        {
            var users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "Vitor",
                    Active = true,
                    Email = "test@email.com",
                    Password = "test"
                }
            };

            this.users = users.AsQueryable();
    }
        public void Add(User entity)
        {
            users.ToList().Add(entity);
        }

        public IEnumerable<User> AllIncluding(params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<User, bool>> predicate)
        {
            return users.Any(predicate);
        }

        public List<User> ClassUsers(int classId)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {

        }

        public int Count()
        {
            return users.Count();
        }

        public void Delete(User entity)
        {
            users.ToList().Remove(entity);
        }

        public void DeleteWhere(Expression<Func<User, bool>> predicate)
        {
            //users.ToList().RemoveAll(predicate);
        }

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetSingle(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User GetSingle(Expression<Func<User, bool>> predicate)
        {
           return users.FirstOrDefault(predicate);
        }

        public User GetSingle(Expression<Func<User, bool>> predicate, params Expression<Func<User, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
