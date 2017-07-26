using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;
using TestIt.Utils.Email;

namespace TestIt.Business.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository studentRepository;
        private IEmailService emailService;

        public StudentService(IStudentRepository studentRepository, IEmailService emailService)
        {
            this.studentRepository = studentRepository;
            this.emailService = emailService;
        }

        public IEnumerable<Student> Get()
        {
            return studentRepository.GetAll();
        }

        public Student GetSingle(int id)
        {
            return studentRepository.GetSingle(id);
        }

        public Student GetByUser(int id)
        {
            return studentRepository.GetSingle(s => s.UserId == id);
        }

        public void Save(Student s)
        {
            studentRepository.Add(s);
            studentRepository.Commit();
        }

        public void Delete(int id)
        {
            Student s = studentRepository.GetSingle(id);

            if (s != null)
            {
                studentRepository.DeleteWhere(x => x.Id == s.Id);
                studentRepository.Commit();
            }
        }

        public void Update(int id, Student student)
        {
            Student s = studentRepository.GetSingle(id);
            if (s != null && student.Id == s.Id)
            {
                studentRepository.Update(student);
                studentRepository.Commit();
            }
        }

        public void SendInvite(User user, Class studentClass)
        {
            var subject = "TestIt - Adicionado a Turma";
            var bodyContent = "Você foi adicionado a turma " + studentClass.Description;
            var email = BuildEmail(user, subject, bodyContent);
            emailService.Send(email);
        }

        public void SendSignUp(User user, int studentId)
        {
            var subject = "TestIt - Finalize o seu cadastro";
            var bodyContent = "http://testitapp.herokuapp.com/#/signup/" + studentId;
            var email = BuildEmail(user, subject, bodyContent);
            emailService.Send(email);
        }

        private Email BuildEmail(User user, string subject, string bodyContent)
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
