
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private Business.IQuestionService questionService;
        private Business.ITestService testService;

        public QuestionController(IQuestionService questionService, ITestService testService)
        {
            this.questionService = questionService;
            this.testService = testService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateQuestionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Question question = Mapper.Map<Question>(viewModel);

            questionService.Save(question);
            testService.AddQuestion(question);

            OkObjectResult result = Ok(new { questionId = question.Id });

            return result;
        }

    }
}
