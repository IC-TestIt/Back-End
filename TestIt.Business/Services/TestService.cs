using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TestService : ITestService
    {
        private ITestRepository testRepository;
        private IQuestionRepository questionRepository;

        public TestService(ITestRepository testRepository, IQuestionRepository questionRepository)
        {
            this.testRepository = testRepository;
            this.questionRepository = questionRepository;
        }
        public void Save(Test t)
        {
            testRepository.Add(t);
            testRepository.Commit();
        }

        public IEnumerable<Question> TestQuestions(int id)
        {
            return questionRepository.TestQuestions(id);
        }
    }
}