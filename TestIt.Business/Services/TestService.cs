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

    }
}