using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClassStudentsRepository _classStudentRepository;
        private readonly IClassTestsRepository _classTestsRepository;

        public ClassService (IClassRepository classRepository, IUserRepository userRepository, IClassStudentsRepository classStudentRepository, IClassTestsRepository classTestsRepository)
        {
            _classRepository = classRepository;
            _userRepository = userRepository;
            _classStudentRepository = classStudentRepository;
            _classTestsRepository = classTestsRepository;
        }
        public void Save(Class c)
        {
            _classRepository.Add(c);
            _classRepository.Commit();
        }

        public IEnumerable<User> ClassUsers (int id)
        {
            return _userRepository.ClassUsers(id);
        }

        public Class GetSingle(int id)
        {
            return _classRepository.GetSingle(id);
        }

        public IEnumerable<Class> Get()
        {
            return _classRepository.GetAll();
        }

        public TeacherClassesDTO GetTeacherClasses(int id)
        {
            var classes = _classRepository.GetTeacherClasses(id);

            var Teacherclasses = new TeacherClassesDTO()
            {
                Classes = classes,
            };

            return Teacherclasses;
        }
        public void Delete(int id)
        {
            _classRepository.DeleteWhere(x => x.Id == id);
            _classRepository.Commit();
        }

        public void DeleteStudent(int id, int studentId)
        {
            _classStudentRepository.DeleteWhere(x => x.ClassId == id && x.StudentId == studentId);
            _classStudentRepository.Commit();
        }

        public void DeleteClassStudents(int id)
        {
            _classStudentRepository.DeleteWhere(x => x.ClassId == id);
            _classStudentRepository.Commit();
        }
        public void DeleteClassTests(int id)
        {
            _classTestsRepository.DeleteWhere(x => x.ClassId == id);
            _classTestsRepository.Commit();
        }

    }
}
