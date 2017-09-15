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

            var alternativeQuestions = new List<AlternativeQuestion>();
            var essayQuestions = new List<EssayQuestion>();

            foreach (var q in viewModel)
            {
                var question = Mapper.Map<Question>(q);
                questionService.Save(question);


                if(q.Answer != null)
                {
                    EssayQuestion essayQuestion = Mapper.Map<EssayQuestion>(q);
                    essayQuestion.QuestionId = question.Id;

                    essayQuestions.Add(essayQuestion);
                }
                else
                {
                    AlternativeQuestion alternativeQuestion = Mapper.Map<AlternativeQuestion>(q);
                    alternativeQuestion.QuestionId = question.Id;

                    alternativeQuestions.Add(alternativeQuestion);
                }
            }

            questionService.Save(alternativeQuestions);
            questionService.Save(essayQuestions);


            OkObjectResult result = Ok("Cadastro Realizado");

            return result;

        }
    }
}
