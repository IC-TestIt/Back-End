using TestIt.Data.Abstract;
using TestIt.Model.Entities;
using System.Linq;
using System;
using System.Collections.Generic;

namespace TestIt.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questionRepository;
        private IEssayQuestionRepository essayRepository;
        private IAlternativeQuestionRepository alternativeQuestionRepository;
        private IAlternativeRepository alternativeRepository;

        public QuestionService(IQuestionRepository questionRepository, IEssayQuestionRepository essayRepository,
                               IAlternativeQuestionRepository alternativeQuestionRepository, IAlternativeRepository alternativeRepository)
        {
            this.questionRepository = questionRepository;
            this.essayRepository = essayRepository;
            this.alternativeQuestionRepository = alternativeQuestionRepository;
            this.alternativeRepository = alternativeRepository;
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

        public void Save(AlternativeQuestion q)
        {
            alternativeQuestionRepository.Add(q);
            alternativeQuestionRepository.Commit();
        }
    }
}
