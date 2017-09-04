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
        private IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateExamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exam exam = Mapper.Map<Exam>(viewModel);

            examService.Save(exam);

            OkObjectResult result = Ok(new { examId = exam.Id });

            return result;
        }
        
        [HttpPut("{id}")]
        public IActionResult EndExam(int id, [FromBody]EndExamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exam exam = Mapper.Map<Exam>(viewModel);

            var sucess = examService.EndExam(id, exam);

            if (sucess)
                return new NoContentResult();
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
    }
}
