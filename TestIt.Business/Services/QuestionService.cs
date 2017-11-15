using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IEssayQuestionRepository _essayRepository;
        private readonly IAlternativeQuestionRepository _alternativeQuestionRepository;
        private readonly IAlternativeRepository _alternativeRepository;

        public QuestionService(IQuestionRepository questionRepository, IEssayQuestionRepository essayRepository,
                               IAlternativeQuestionRepository alternativeQuestionRepository, IAlternativeRepository alternativeRepository)
        {
            _questionRepository = questionRepository;
            _essayRepository = essayRepository;
            _alternativeQuestionRepository = alternativeQuestionRepository;
            _alternativeRepository = alternativeRepository;
        }

        public void Save(Question q)
        {
            _questionRepository.AddOrUpdate(q);
            _questionRepository.Commit();
        }

        public void Save(List<EssayQuestion> q)
        {
            _essayRepository.AddOrUpdateMultiple(q);
            _essayRepository.Commit();
        }

        public void Save(List<AlternativeQuestion> q)
        {
            _alternativeQuestionRepository.AddMultiple(q);
            _alternativeQuestionRepository.Commit();
        }

        public void Remove(IEnumerable<int> questionsId)
        {
            foreach (var id in questionsId)
            {
                _alternativeRepository.DeleteWhere(x => x.AlternativeQuestion.QuestionId == id);
                _alternativeQuestionRepository.DeleteWhere(x => x.QuestionId == id);
                _essayRepository.DeleteWhere(x => x.QuestionId == id);
                _questionRepository.DeleteWhere(x => x.Id == id);

                _alternativeRepository.Commit();

            }
        }
        public void Update(List<AlternativeQuestion> q)
        {
            q.ForEach(x =>
            {
                _alternativeQuestionRepository.Update(x);
                _alternativeRepository.AddOrUpdateMultiple(x.Alternatives.ToList());
            });
            _alternativeRepository.Commit();
        }

    }
}
