using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Question;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.Utils.Extend;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<QuestionsViewModel> viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionsViewModel = viewModel as IList<QuestionsViewModel> ?? viewModel.ToList();

            questionsViewModel.ForEachWithIndex((item, index) => item.Order = index);
            
            _questionService.Save(AddAlternativeQuestions(questionsViewModel));
            _questionService.Save(AddEssayQuestions(questionsViewModel));

            var result = Ok("Cadastro Realizado");

            return result;

        }

        [HttpPut]
        public IActionResult UpdateRemoveQuestions([FromBody]UpdateQuestionsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            _questionService.Save(AddEssayQuestions(viewModel.QuestionsUpdate.ToList()));
            _questionService.Save(AddAlternativeQuestions(viewModel.QuestionsUpdate.ToList()));

            _questionService.Update(UpdateAlternativeQuestions(viewModel.QuestionsUpdate.ToList()));

            _questionService.Remove(viewModel.QuestionsRemove.ToList());

            var result = Ok("Operação Realizada");

            return result;
        }

        public List<AlternativeQuestion> AddAlternativeQuestions(IEnumerable<QuestionsViewModel> viewModel)
        {
            var alternativeQuestions = new List<AlternativeQuestion>();

            foreach (var q in viewModel)
            {
                var question = Mapper.Map<Question>(q);
                
                if (string.IsNullOrEmpty(q.Answer) && q.Id == 0)
                {
                    _questionService.Save(question);

                    var alternativeQuestion = Mapper.Map<AlternativeQuestion>(q);
                    alternativeQuestion.QuestionId = question.Id;

                    alternativeQuestions.Add(alternativeQuestion);
                }
            }

            return alternativeQuestions;
        }

        public List<AlternativeQuestion> UpdateAlternativeQuestions(IEnumerable<QuestionsViewModel> viewModel)
        {
            var alternativeQuestions = new List<AlternativeQuestion>();

            foreach (var q in viewModel)
            {
                var question = Mapper.Map<Question>(q);

                if (!string.IsNullOrEmpty(q.Answer) || q.Id == 0) continue;
                _questionService.Save(question);

                var alternativeQuestion = Mapper.Map<AlternativeQuestion>(q);

                alternativeQuestions.Add(alternativeQuestion);
            }

            return alternativeQuestions;
        }

        public List<EssayQuestion> AddEssayQuestions(IEnumerable<QuestionsViewModel> viewModel)
        {
            var essayQuestions = new List<EssayQuestion>();

            foreach (var q in viewModel)
            {
                var question = Mapper.Map<Question>(q);

                if (string.IsNullOrEmpty(q.Answer)) continue;
                _questionService.Save(question);

                var essayQuestion = Mapper.Map<EssayQuestion>(q);
                essayQuestion.QuestionId = question.Id;

                essayQuestions.Add(essayQuestion);
            }

            return essayQuestions;
        }


    }
}
