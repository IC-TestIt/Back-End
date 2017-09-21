using System;
using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        
        public UserService (IUserRepository userRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }
        
        public bool ValidLogin(string email, string pswd)
        {
            return _userRepository.Any(x => x.Email == email && x.Password == pswd);
        }

        public IEnumerable<User> Get() 
        {
            return _userRepository.GetAll();
        }

        public User GetSingle(int id)
        {
            return _userRepository.GetSingle(id);
        }

        public bool Save(User t)
        {
            if (Exists(t.Email) != 0) return false;
            _userRepository.Add(t);
            _userRepository.Commit();
            return true;
        }

        public void Delete(int id)
        {
            var t = _userRepository.GetSingle(id);

            if (t == null) return;
            _userRepository.DeleteWhere(x => x.Id == t.Id);
            _userRepository.Commit();
        }

        public bool Update(int id, User user)
        {
            var t = _userRepository.GetSingle(id);

            if (t == null) return false;
            t.DateUpdated = DateTime.Now;
            t.Birthday = user.Birthday;
            t.Password = user.Password;
            t.Phone = user.Phone;
            t.OrganizationId = user.OrganizationId;

            _userRepository.Commit();

            return true;
        }

        public int Exists(string email)
        {
            var u =  _userRepository.GetSingle(x => x.Email == email);
            return u?.Id ?? 0;
        }

        public LoggedUser GetByEmail(string email)
        {
            var loggedUser = new LoggedUser();

            var user = _userRepository.GetSingle(x => x.Email == email);

            if (user != null)
                loggedUser.UserId = user.Id;

            var student = _studentRepository.GetSingle(x => x.UserId == user.Id);

            if (student != null)
                loggedUser.StudentId = student.Id;

            var teacher = _teacherRepository.GetSingle(x => x.UserId == user.Id);

            if (teacher != null)
                loggedUser.TeacherId = teacher.Id;

            return loggedUser;
        }
    }
}
