using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ClassService : IClassService
    {
        private IClassRepository classRepository;
        private IUserRepository userRepository;
        private IClassStudentsRepository classStudentRepository;
        private IClassTestsRepository classTestsRepository;

        public ClassService (IClassRepository classRepository, IUserRepository userRepository, IClassStudentsRepository classStudentRepository, IClassTestsRepository classTestsRepository)
        {
            this.classRepository = classRepository;
            this.userRepository = userRepository;
            this.classStudentRepository = classStudentRepository;
            this.classTestsRepository = classTestsRepository;
        }
        public void Save(Class c)
        {
            classRepository.Add(c);
            classRepository.Commit();
        }

        public IEnumerable<User> ClassUsers (int id)
        {
            return userRepository.ClassUsers(id);
        }

        public Class GetSingle(int id)
        {
            return classRepository.GetSingle(id);
        }

        public IEnumerable<Class> Get()
        {
            return classRepository.GetAll();
        }

        public IEnumerable<Class> GetTeacherClasses(int id)
        {
            var classes = classRepository.FindByIncluding(x => x.TeacherId == id, x=> x.ClassStudents);
            return classes;
        }
        public void Delete(int id)
        {
            classRepository.DeleteWhere(X => X.Id == id);
            classRepository.Commit();
        }

        public void DeleteStudent(int id, int studentId)
        {
            classStudentRepository.DeleteWhere(x => x.ClassId == id && x.StudentId == studentId);
            classStudentRepository.Commit();
        }

        public void DeleteClassStudents(int id)
        {
            classStudentRepository.DeleteWhere(x => x.ClassId == id);
            classStudentRepository.Commit();
        }
        public void DeleteClassTests(int id)
        {
            classTestsRepository.DeleteWhere(x => x.ClassId == id);
            classTestsRepository.Commit();
        }

    }
}
