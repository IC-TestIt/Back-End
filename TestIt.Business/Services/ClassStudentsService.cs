using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ClassStudentsService : IClassStudentsService
    {
        private readonly IClassStudentsRepository _classStudentsRepository;

        public ClassStudentsService(IClassStudentsRepository classStudentsRepository)
        {
            _classStudentsRepository = classStudentsRepository;
        }

        public bool Save(ClassStudents cs)
        {
            if (_classStudentsRepository.Any(x => x.ClassId == cs.ClassId && x.StudentId == cs.StudentId))
                return false;

            _classStudentsRepository.Add(cs);
            _classStudentsRepository.Commit();

            return true;
        }

        public void DeleteStudent(int id, int studentId)
        {
            _classStudentsRepository.DeleteWhere(x => x.ClassId == id && x.StudentId == studentId);
            _classStudentsRepository.Commit();
        }

        public IEnumerable<StudentClassDTO> GetClasses(int id)
        {
            return _classStudentsRepository.GetClasses(id);

        }


    }
}
