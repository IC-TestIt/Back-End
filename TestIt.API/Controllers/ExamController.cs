using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestIt.API.ViewModels.Exam;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ExamController : Controller
    {
        private IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateExamViewModel viewModel)
        {
            OkObjectResult result;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exam exam = Mapper.Map<Exam>(viewModel);

            if (!examService.ExistsExam(exam))
            {
                examService.Save(exam);
                result = Ok(new { examId = exam.Id });
            }
            else
                result = Ok("Esse aluno já esta realizando essa prova");

            return result;
        }
        
        [HttpPut("{id}")]
        public IActionResult EndExam(int id, [FromBody]EndExamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerdQuestions = Mapper.Map<List<AnsweredQuestion>>(viewModel.AnsweredQuestions);

            var sucess = examService.EndExam(id, answerdQuestions);

            if (sucess)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("save/{id}")]
        public IActionResult SaveExam(int id, [FromBody]EndExamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerdQuestions = Mapper.Map<List<AnsweredQuestion>>(viewModel.AnsweredQuestions);

            var sucess = examService.SaveExam(id, answerdQuestions);

            if (sucess)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get (int id)
        {
            var exam = examService.Get(id);

            if (exam != null)
            {
                var vm = Mapper.Map<ReturnExamViewModel>(exam);

                return Ok(vm);
            }

            return NotFound();
        }

        [HttpPost("correct/{id}")]
        public IActionResult Post(int id)
        {
            var sucess = examService.Correct(id);

            if (sucess)
                return Ok();

            return NotFound();
        }
    }
}
