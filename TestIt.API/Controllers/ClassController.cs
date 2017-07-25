using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Mappings;
using TestIt.API.ViewModels.Class;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.Utils.Email;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private Business.IClassService classService;
        private Business.IClassStudentsService classStudentService;
        private IEmailService emailService;
        private IStudentService studentService;
        private IUserService userService;

        public ClassController(IClassService classService, IClassStudentsService classStudentService, IEmailService emailService, IStudentService studentService, IUserService userService)
        {
            this.classService = classService;
            this.classStudentService = classStudentService;
            this.emailService = emailService;
            this.studentService = studentService;
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateClassViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Class newClass = Mapper.Map<Class>(viewModel);

            classService.Save(newClass);

            OkObjectResult result = Ok(new { classId = newClass.Id});

            return result;
        }

        [HttpPost("{id}/student/{studentId}")]
        public IActionResult Post(int id, int studentId)
        {
            classStudentService.Save(new ClassStudents()
            {
                ClassId = id,
                StudentId = studentId
            });

            OkObjectResult result = Ok(new { classId = id, studentId = studentId });

            var Student = studentService.GetSingle(studentId);
            var User = userService.GetSingle(Student.UserId);
            var Class = classService.GetSingle(id);

            emailService.SendInvite(User.Email, User.Name, Class.Description);

            return result;
        }

        [HttpGet("{id}/users")]
        public IActionResult Get (int id)
        {
            OkObjectResult result = Ok(classService.ClassUsers(id));

            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            OkObjectResult result = Ok(classService.ClassUsers(id));

            return result;
        }
    }
}
