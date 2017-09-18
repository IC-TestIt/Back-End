using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;
        private IClassTestsRepository _classTestRepository;

        public TeacherService(ITeacherRepository teacherRepository, IClassTestsRepository classTestRepository)
        {
            _teacherRepository = teacherRepository;
            _classTestRepository = classTestRepository;
        }

        public IEnumerable<Teacher> Get() 
        {
            return _teacherRepository.GetAll();
        }

        public Teacher GetSingle(int id)
        {
            return _teacherRepository.GetSingle(id);
        }

        public Teacher GetByUser(int id) 
        {
            return _teacherRepository.GetSingle(t => t.UserId == id);
        }

        public void Save(Teacher t) 
        {
            _teacherRepository.Add(t);
            _teacherRepository.Commit();
        }

        public void Delete(int id)
        {
            Teacher t = _teacherRepository.GetSingle(id);

            if(t != null) 
            {
                _teacherRepository.DeleteWhere(x => x.Id == t.Id);
                _teacherRepository.Commit();
            }
        }

        public void Update(int id, Teacher teacher)
        {
            Teacher t = _teacherRepository.GetSingle(id);
            if (t != null && teacher.Id == t.Id)
            {
                _teacherRepository.Update(teacher);
                _teacherRepository.Commit();
            }
        }
        
        public IEnumerable<ClassTests> GetClassTests(int id)
        {
            var classTests = _classTestRepository.FindByIncluding(x => x.Test.TeacherId == id, x => x.Test, x => x.Class);

            return classTests;
        }
    }
}