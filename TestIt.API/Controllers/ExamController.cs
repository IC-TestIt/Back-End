using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Exam;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.API.ViewModels.Test;
using TestIt.API.ViewModels.Class;
using TestIt.Model.DTO;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly ITestService _testService;

        public ExamController(IExamService examService, ITestService testService)
        { 
            _examService = examService;
            _testService = testService ;  
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
            var currentExam = _examService.ExistsExam(exam);

            if (currentExam == 0)
            {
                _examService.Save(exam);
                result = Ok(new { examId = exam.Id });
            }
            else
                result = Ok(new { examId = currentExam });

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

        [HttpPut("{id}/saved")]
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

        [HttpPost("{id}/correct")]
        public IActionResult Post(int id)
        {
            var sucess = _examService.Correct(id);

            if (sucess)
                return Ok();

            return Ok(0);
        }
        
        [HttpPut("correction")]
        public IActionResult ExamsRealCorrection([FromBody]ExamsRealCorrectionViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exams = Mapper.Map<IEnumerable<Exam>>(viewModel.Corrections);

            var sucess = _examService.ExamsRealCorrection(exams);

            if (sucess)
                return Ok();

            return Ok(0);
        }

        [HttpGet("{id}/correction")]
        public IActionResult GetExamCorrection(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exam = _examService.GetStudentCorrection(id);

            var vm = Mapper.Map<StudentExamCorrectionViewModel>(exam);

            if (vm != null)
                return Ok(vm);

            return Ok(0);
        }
    }
}
