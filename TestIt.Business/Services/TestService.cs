using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TestService : ITestService
    {
        private ITestRepository testRepository;

        public TestService(ITestRepository testRepository)
        {
            this.testRepository = testRepository;

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
            return testRepository.GetSingle(x => x.Id == id, x => x.Questions);
        }


    }
}