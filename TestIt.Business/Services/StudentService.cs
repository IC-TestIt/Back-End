using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using TestIt.Utils.Email;

namespace TestIt.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailService _emailService;

        public StudentService(IStudentRepository studentRepository, IEmailService emailService)
        {
            _studentRepository = studentRepository;
            _emailService = emailService;
        }

        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetAll();
        }

        public Student GetSingle(int id)
        {
            return _studentRepository.GetSingle(id);
        }

        public Student GetByUser(int id)
        {
            return _studentRepository.GetSingle(s => s.UserId == id);
        }

        public void Save(Student s)
        {
            _studentRepository.Add(s);
            _studentRepository.Commit();
        }

        public void Delete(int id)
        {
            var s = _studentRepository.GetSingle(id);

            if (s == null) return;
            _studentRepository.DeleteWhere(x => x.Id == s.Id);
            _studentRepository.Commit();
        }

        public void Update(int id, Student student)
        {
            var s = _studentRepository.GetSingle(id);
            if (s == null || student.Id != s.Id) return;
            _studentRepository.Update(student);
            _studentRepository.Commit();
        }

        public void SendInvite(User user, Class studentClass)
        {
            const string subject = "TestIt - Adicionado a Turma";
            var bodyContent = "Você foi adicionado a turma " + studentClass.Description;
            var email = BuildEmail(user, subject, bodyContent);
            _emailService.Send(email);
        }

        public void SendSignUp(User user, int studentId)
        {
            const string subject = "TestIt - Finalize o seu cadastro";
            var bodyContent = "http://testitapp.herokuapp.com/#/signup/" + studentId;
            var email = BuildEmail(user, subject, bodyContent);
            _emailService.Send(email);
        }

        public IEnumerable<StudentTestDTO> Tests(int id)
        {
            return _studentRepository.GetTests(id);
        }

        private static Email BuildEmail(User user, string subject, string bodyContent)
        {
            var email = new Email
            {
                ToAdress = user.Email,
                ToAdressTitle = user.Name,
                Subject = subject,
                BodyContent = bodyContent
            };

            return email;
        }
    }
}
