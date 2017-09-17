using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.API.ViewModels.Question;
using System.Linq;
using System.Collections.Generic;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private IQuestionService questionService;
        private ITestService testService;

        public QuestionController(IQuestionService questionService, ITestService testService)
        {
            this.questionService = questionService;
            this.testService = testService;
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<QuestionsViewModel> viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            questionService.Save(AddAlternativeQuestions(viewModel));
            questionService.Save(AddEssayQuestions(viewModel));

            OkObjectResult result = Ok("Cadastro Realizado");

            return result;

        }

        [HttpPut("{id}/test")]
        public IActionResult UpdateRemoveQuestions(int id ,[FromBody]UpdateQuestionsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            questionService.Remove(viewModel.questionsRemove.ToList());

            //questionService.Save(AddEssayQuestions(viewModel.QuestionsUpdate.ToList()));
            //questionService.Update(AddAlternativeQuestions(viewModel.QuestionsUpdate.ToList()));

            OkObjectResult result = Ok("Exclusão Realizada");

            return result;
        }

        public List<AlternativeQuestion> AddAlternativeQuestions(IEnumerable<QuestionsViewModel> viewModel)
        {
            var alternativeQuestions = new List<AlternativeQuestion>();

            foreach (var q in viewModel)
            {
                var question = Mapper.Map<Question>(q);
                
                if (string.IsNullOrEmpty(q.Answer))
                {
                    questionService.Save(question);

                    AlternativeQuestion alternativeQuestion = Mapper.Map<AlternativeQuestion>(q);
                    alternativeQuestion.QuestionId = question.Id;

                    alternativeQuestions.Add(alternativeQuestion);
                }
            }

            return alternativeQuestions;
        }

        public List<EssayQuestion> AddEssayQuestions(IEnumerable<QuestionsViewModel> viewModel)
        {
            var essayQuestions = new List<EssayQuestion>();

            foreach (var q in viewModel)
            {
                var question = Mapper.Map<Question>(q);
               
                if (!string.IsNullOrEmpty(q.Answer))
                {
                    questionService.Save(question);

                    EssayQuestion essayQuestion = Mapper.Map<EssayQuestion>(q);
                    essayQuestion.QuestionId = question.Id;

                    essayQuestions.Add(essayQuestion);
                }
            }

            return essayQuestions;
        }


    }
}
