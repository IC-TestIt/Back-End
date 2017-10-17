using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Exam;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateExamViewModel viewModel)
        {
            OkObjectResult result;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exam = Mapper.Map<Exam>(viewModel);

            if (!_examService.ExistsExam(exam))
            {
                _examService.Save(exam);
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

            var sucess = _examService.EndExam(id, answerdQuestions);

            if (sucess)
                return Ok();
            return Ok(0);
        }

        [HttpPut("save/{id}")]
        public IActionResult SaveExam(int id, [FromBody]EndExamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var answerdQuestions = Mapper.Map<List<AnsweredQuestion>>(viewModel.AnsweredQuestions);

            var sucess = _examService.SaveExam(id, answerdQuestions);
            
            if (sucess)
                return Ok();
            return Ok(0);
        }

        [HttpGet("{id}")]
        public IActionResult Get (int id)
        {
            var exam = _examService.Get(id);

            if (exam != null)
            {
                var vm = Mapper.Map<ReturnExamViewModel>(exam);

                return Ok(vm);
            }

            return Ok(0);
        }

        [HttpPost("correct/{id}")]
        public IActionResult Post(int id)
        {
            var sucess = _examService.Correct(id);

            if (sucess)
                return Ok();

            return Ok(0);
        }

        [HttpPut("correct")]
        public IActionResult CorrectedExams([FromBody]IEnumerable<CorrectedExamViewModel> viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exams = Mapper.Map<IEnumerable<Exam>>(viewModel);

            var sucess = _examService.CorrectedExams(exams);

            if (sucess)
                return Ok();
            return Ok(0);
        }
    }
}
