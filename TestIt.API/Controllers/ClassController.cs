using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.User;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        private readonly IClassStudentsService _classStudentService;
        private readonly IStudentService _studentService;
        private readonly IUserService _userService;

        public ClassController(IClassService classService, IClassStudentsService classStudentService,
            IStudentService studentService, IUserService userService)
        {
            _classService = classService;
            _classStudentService = classStudentService;
            _studentService = studentService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateClassViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newClass = Mapper.Map<Class>(viewModel);

            _classService.Save(newClass);

            var result = Ok(new {classId = newClass.Id});

            return result;
        }

        [HttpPost("{id}/student/{studentId}")]
        public IActionResult Post(int id, int studentId)
        {
            _classStudentService.Save(new ClassStudents
            {
                ClassId = id,
                StudentId = studentId
            });

            var result = Ok(new {classId = id, studentId});

            var student = _studentService.GetSingle(studentId);
            var user = _userService.GetSingle(student.UserId);
            var classStudent = _classService.GetSingle(id);

            _studentService.SendInvite(user, classStudent);

            return result;
        }

        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            var result = _classService.GetDetails(id);

            return Ok(result);
        }

        [HttpGet("{id}/users")]
        public IActionResult Get(int id)
        {
            var usersClass = _classService.ClassUsers(id);

            if (usersClass == null) return Ok(0);
            var usersVm = Mapper.Map<IEnumerable<User>, IEnumerable<ReturnUserViewModel>>(usersClass);
            return new OkObjectResult(usersVm);
        }

        [HttpDelete("{id}/student/{studentId}")]
        public IActionResult DeleteStudent(int id, int studentId)
        {
            _classStudentService.DeleteStudent(id, studentId);
            return new OkObjectResult("Excluido com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            var c = _classService.GetSingle(id);

            if (c == null) return Ok(0);
            _classService.DeleteClassStudents(id);
            _classService.DeleteClassTests(id);
            _classService.Delete(id);
            return new OkObjectResult("Excluido com sucesso");
        }
    }
}
