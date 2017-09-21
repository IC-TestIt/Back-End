using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Exam;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.DTO;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly IExamService _examService;

        public StudentController(IStudentService studentService, IUserService userService, IExamService examService)
        {
            _studentService = studentService;
            _userService = userService;
            _examService = examService;
        }

        [HttpGet("exists/{email}")]
        public IActionResult StudentExists(string email)
        {
            var userId = _userService.Exists(email);

            if (userId == 0)
            {
                return new OkObjectResult(-1);
            }

            var result = new OkObjectResult(_studentService.GetByUser(userId).Id);
            return result;
        }

        [HttpGet("{id}/exams")]
        public IActionResult GetStudentExams(int id)
        {
            var exams = _examService.GetStudentExams(id);

            if (exams == null) return NotFound();
            var examsVm = Mapper.Map<IEnumerable<ExamDto>, IEnumerable<StudentExamsViewModel>>(exams);
            return new OkObjectResult(examsVm);
        }

        [HttpGet("{id}/tests")]
        public IActionResult GetStudentTest(int id)
        {
            var exams = _studentService.Tests(id);

            if (exams == null) return NotFound();
            var examVm = Mapper.Map<IEnumerable<StudentTestDto>, IEnumerable<StudentTestViewModel>>(exams);

            return new OkObjectResult(examVm);
        }
    }
}
