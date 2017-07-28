using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;


namespace TestIt.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public void Save(Question q)
        {
            questionRepository.Add(q);
            questionRepository.Commit();
        }

    }
}
