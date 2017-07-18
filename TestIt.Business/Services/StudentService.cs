using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class StudentService :IStudentService
    {
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
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
    }
}
