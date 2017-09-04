using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestIt.API.ViewModels.Exam;
using TestIt.Business;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentService studentService;
        private IUserService userService;
        private IExamService examService;

        public StudentController(IStudentService studentService, IUserService userService, IExamService examService)
        {
            this.studentService = studentService;
            this.userService = userService;
            this.examService = examService;
        }

        [HttpGet("exists/{email}")]
        public IActionResult StudentExists(string email)
        {
            var userId = userService.Exists(email);

            if (userId == 0)
            {
                return new OkObjectResult(-1);
            }

            var result = new OkObjectResult(studentService.GetByUser(userId).Id);
            return result;
        }
        [HttpGet("{id}/exams")]
        public IActionResult GetStudentExams(int id)
        {
            var exams = examService.GetStudentExams(id);

            if (exams != null)
            {
                IEnumerable<StudentExamsViewModel> examsVm = Mapper.Map<IEnumerable<ExamDTO>, IEnumerable<StudentExamsViewModel>>(exams);
                return new OkObjectResult(examsVm);
            }

            return NotFound();
        }
    }
}
