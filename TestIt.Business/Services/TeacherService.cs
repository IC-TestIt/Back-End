using System;
using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IClassTestsRepository _classTestRepository;
        private readonly IClassRepository _classRepository;
        private readonly ITestRepository _testRepository;

        public TeacherService(ITeacherRepository teacherRepository, IClassTestsRepository classTestRepository, 
                              IClassRepository classRepository, ITestRepository testRepository)
        {
            _teacherRepository = teacherRepository;
            _classTestRepository = classTestRepository;
            _classRepository = classRepository;
            _testRepository = testRepository;
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
            var t = _teacherRepository.GetSingle(id);

            if (t == null) return;
            _teacherRepository.DeleteWhere(x => x.Id == t.Id);
            _teacherRepository.Commit();
        }

        public void Update(int id, Teacher teacher)
        {
            var t = _teacherRepository.GetSingle(id);
            if (t == null || teacher.Id != t.Id) return;
            _teacherRepository.Update(teacher);
            _teacherRepository.Commit();
        }
        
        public IEnumerable<ClassTests> GetClassTests(int id)
        {
            var classTests = _classTestRepository.FindByIncluding(x => x.Test.TeacherId == id, x => x.Test, x => x.Class);

            return classTests;
        }

        public DashboardDTO GetDashboard(int id)
        {
            var classes = _classRepository.GetTeacherClasses(id);
            var recentTests = _testRepository.GetTeacherTests(id, Model.EnumTestStatus.Uncorrected);

            return new DashboardDTO()
            {
                Classes = classes,
                RecentTests = recentTests
            };
        }
    }
}