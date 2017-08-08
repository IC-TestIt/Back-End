using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.API.ViewModels.Question;
using System.Linq;

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
        [Route("essay")]
        public IActionResult Post([FromBody]CreateEssayQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Question question = Mapper.Map<Question>(viewModel);
            EssayQuestion essayQuestion = Mapper.Map<EssayQuestion>(viewModel);
            
            questionService.Save(question);

            essayQuestion.QuestionId = question.Id;
            questionService.Save(essayQuestion);

            OkObjectResult result = Ok(new { questionId = question.Id, essayQuestionId = essayQuestion.Id });

            return result;
        }

        [HttpPost]
        [Route("alternative")]
        public IActionResult Post([FromBody]CreateAlternativeQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Question question = Mapper.Map<Question>(viewModel);
            AlternativeQuestion alternativeQuestion = Mapper.Map<AlternativeQuestion>(viewModel);

            questionService.Save(question);

            alternativeQuestion.QuestionId = question.Id;

            questionService.Save(alternativeQuestion);

            OkObjectResult result = Ok(new { questionId = question.Id, alternativeQuestionId = alternativeQuestion.Id });

            return result;
        }
    }
}
