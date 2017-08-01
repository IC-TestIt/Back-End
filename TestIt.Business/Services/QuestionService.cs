using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;


namespace TestIt.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questionRepository;
        public IEssayQuestionRepository essayRepository;

        public QuestionService(IQuestionRepository questionRepository, IEssayQuestionRepository essayRepository)
        {
            this.questionRepository = questionRepository;
            this.essayRepository = essayRepository;
        }

        public void Save(Question q)
        {
            questionRepository.Add(q);
            questionRepository.Commit();
        }

        public void Save(EssayQuestion q)
        {
            essayRepository.Add(q);
            essayRepository.Commit();
        }
    }
}
