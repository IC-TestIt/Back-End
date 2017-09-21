using TestIt.Data.Abstract;
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

        public void Save(ClassStudents cs)
        {
            _classStudentsRepository.Add(cs);
            _classStudentsRepository.Commit();
        }

        public void DeleteStudent(int id, int studentId)
        {
            _classStudentsRepository.DeleteWhere(x => x.ClassId == id && x.StudentId == studentId);
            _classStudentsRepository.Commit();
        }


    }
}
