using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Exam;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.DTO;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.ClassStudents;
using TestIt.API.ViewModels.Student;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;
        private readonly IExamService _examService;
        private readonly IClassStudentsService _classStudentsService;

        public StudentController(IStudentService studentService, IUserService userService, IExamService examService, 
                                                                                            IClassStudentsService classStudentsService)
        {
            _studentService = studentService;
            _userService = userService;
            _examService = examService;
            _classStudentsService = classStudentsService;
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

            if (exams == null) return Ok(0);
            var examsVm = Mapper.Map<IEnumerable<ExamDto>, IEnumerable<StudentExamsViewModel>>(exams);
            return new OkObjectResult(examsVm);
        }
        
        [HttpGet("{id}/dashboard")]
        public IActionResult GetStudentDashboard(int id)
        {
            var exams = _studentService.Tests(id);
            
            var classes = _classStudentsService.GetClasses(id);

            if (classes == null && exams == null)
                return Ok(0);

            var examVm = Mapper.Map<IEnumerable<StudentTestDTO>, IEnumerable<StudentTestViewModel>>(exams);
            var classVm = Mapper.Map<IEnumerable<StudentClassDTO>, IEnumerable<StudentClassViewModel>>(classes);

            var dashboardVm = new DashboardViewModel()
            {
                Classes = classVm,
                Tests = examVm
            };

            return Ok(dashboardVm);
        }
    }
}
