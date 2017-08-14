using System;
using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;
using TestIt.Model.DTO;

namespace TestIt.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IStudentRepository studentRepository;
        private ITeacherRepository teacherRepository;
        
        public UserService (IUserRepository userRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            this.userRepository = userRepository;
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
        }
        
        public bool ValidLogin(string email, string pswd)
        {
            return userRepository.Any(x => x.Email == email && x.Password == pswd);
        }

        public IEnumerable<User> Get() 
        {
            return userRepository.GetAll();
        }

        public User GetSingle(int id)
        {
            return userRepository.GetSingle(id);
        }

        public void Save(User t) 
        {
            userRepository.Add(t);
            userRepository.Commit();
        }

        public void Delete(int id)
        {
            User t = userRepository.GetSingle(id);

            if(t != null) 
            {
                userRepository.DeleteWhere(x => x.Id == t.Id);
                userRepository.Commit();
            }
        }

        public bool Update(int id, User user)
        {
            User t = userRepository.GetSingle(id);

            if (t != null)
            {
                t.DateUpdated = DateTime.Now;
                t.Birthday = user.Birthday;
                t.Password = user.Password;
                t.Phone = user.Phone;
                t.OrganizationId = user.OrganizationId;

                userRepository.Commit();

                return true;
            }
            else
                return false;
        }

        public int Exists(string email)
        {
            var u =  userRepository.GetSingle(x => x.Email == email);
            return u == null ? 0 : u.Id;
        }

        public LoggedUser GetByEmail(string email)
        {
            LoggedUser loggedUser = new LoggedUser();

            var user = userRepository.GetSingle(x => x.Email == email);

            if (user != null)
                loggedUser.UserId = user.Id;

            var student = studentRepository.GetSingle(x => x.UserId == user.Id);

            if (student != null)
                loggedUser.StudentId = student.Id;

            var teacher = teacherRepository.GetSingle(x => x.UserId == user.Id);

            if (teacher != null)
                loggedUser.TeacherId = teacher.Id;

            return loggedUser;
        }
    }
}
