using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TestService : ITestService
    {
        private ITestRepository testRepository;
        private IClassTestsRepository classTestsRepository;

        public TestService(ITestRepository testRepository, IClassTestsRepository classTestsRepository)
        {
            this.testRepository = testRepository;
            this.classTestsRepository = classTestsRepository;

        }
        public void Save(Test t)
        {
            testRepository.Add(t);
            testRepository.Commit();
        }

        public void AddQuestion(Question q)
        {
            var test = testRepository.GetSingle(q.TestId);
            test.Questions.Add(q);
            testRepository.Update(test);
            testRepository.Commit();
        }

        public IEnumerable<Test> Get()
        {
            return testRepository.AllIncluding(x => x.Questions);
        }
  
        public Test GetSingle(int id)
        {
            return testRepository.SingleIncluding(id, x => x.Questions);
        }

        public IEnumerable<Test> GetTeacherTests(int id)
        {
            var tests = testRepository.FindBy(x => x.TeacherId == id);
            return tests; 
        }

        public bool Save(List<ClassTestsDTO> cts)
        {
            return false;
        }

        public bool Exists(int classId, int testId)
        {
            return  classTestsRepository.Any(x => x.ClassId  == classId && x.TestId == testId);
        }

    }
}