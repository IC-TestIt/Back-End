using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model.Entities;

namespace TestIt.Business
{
    public interface IUserService
    {
        bool ValidLogin(string email, string pswd);
        IEnumerable<User> Get();

        User GetSingle(int id);

        void Save(User u);

        void Delete(int id);

        void Update(int id, User u);
    }

    public interface ITeacherService 
    {
        IEnumerable<Teacher> Get();

        Teacher GetSingle(int id);

        void Save(Teacher t);

        void Delete(int id);

        void Update(int id, Teacher teacher);

        Teacher GetByUser(int id);
    }
}
