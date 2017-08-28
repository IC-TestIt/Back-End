using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
