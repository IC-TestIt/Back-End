using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Mappings;
using TestIt.API.ViewModels.Class;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.API.ViewModels.User;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private IClassService classService;
        private IClassStudentsService classStudentService;
        private IStudentService studentService;
        private IUserService userService;
        private IClassTestsService classTestsService;

        public ClassController(IClassService classService, IClassStudentsService classStudentService, IStudentService studentService, IUserService userService, IClassTestsService classTestsService)
        {
            this.classService = classService;
            this.classStudentService = classStudentService;
            this.studentService = studentService;
            this.userService = userService;
            this.classTestsService = classTestsService;
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

            var student = studentService.GetSingle(studentId);
            var user = userService.GetSingle(student.UserId);
            var classStudent = classService.GetSingle(id);

            studentService.SendInvite(user, classStudent);

            return result;
        }
        
        [HttpGet("{id}")]
        public IActionResult GetUsers(int id)
        {
            OkObjectResult result = Ok(classService.ClassUsers(id));

            return result;
        }

        [HttpGet("{id}/users")]
        public IActionResult Get (int id)
        {
            IEnumerable<User> usersClass = classService.ClassUsers(id);

            if (usersClass != null)
            {
                IEnumerable<ReturnUserViewModel> usersVm = Mapper.Map<IEnumerable<User>, IEnumerable<ReturnUserViewModel>>(usersClass);
                return new OkObjectResult(usersVm);
            }

            return NotFound();

        }
        
        [HttpDelete("{id}/student/{studentId}")]
        public IActionResult DeleteStudent(int id, int studentId)
        {
                classStudentService.DeleteStudent(id, studentId);
                return new OkObjectResult("Excluido com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClass(int id)
        {
            Class c = classService.GetSingle(id);

            if( c != null)
            {

                classStudentService.Delete(id);
                classTestsService.Delete(id);
                classService.Delete(id);
                return new OkObjectResult("Excluido com sucesso");
            }

            return NotFound();
        }
    }
}
