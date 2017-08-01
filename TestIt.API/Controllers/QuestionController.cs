using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.API.ViewModels.Question;

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
    }
}
