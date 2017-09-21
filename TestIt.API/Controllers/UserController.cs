using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.User;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public UserController(IUserService userService, ITeacherService teacherService, IStudentService studentService)
        {
            _userService = userService;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.Get();

            if (users == null) return NotFound();
            var usersVm = Mapper.Map<IEnumerable<User>, IEnumerable<ReturnUserViewModel>>(users);
            return new OkObjectResult(usersVm);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetSingle(id);

            if (user == null) return NotFound();
            var userVm = Mapper.Map<User, ReturnUserViewModel>(user);
            return new OkObjectResult(userVm); //TODO: UserViewModel
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateUserViewModel viewModel)
        {
            OkObjectResult result;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Mapper.Map<User>(viewModel);

            user.IsActive = true;
            if (_userService.Save(user))
            {
                if (viewModel.Type == 1)
                {
                    var teacherId = CreateTeacher(user);

                    result = Ok(new {teacherId, userId = user.Id });
                }
                else
                {
                    var studentId = CreateStudent(user);

                    result = Ok(new {studentId, userId = user.Id });
                }

            }
            else
                return Forbid();

            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Mapper.Map<User>(viewModel);

            var sucess = _userService.Update(id, user);

            if (sucess)
                return new NoContentResult();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetSingle(id);

            if (user == null)
                return new NotFoundResult();
            var tId = GetTeacherId(user.Id);
            var sId = GetStudentId(user.Id);
                
            if (tId != 0)
                _teacherService.Delete(tId);
            if (sId != 0)
                _studentService.Delete(sId);
                
            _userService.Delete(id);

            return new NoContentResult();
        }

        [HttpGet("exists/{email}")]
        public int UserExists(string email)
        {
            return _userService.Exists(email);
        }


        private int CreateStudent(User user)
        {
            var student = new Student
            {
                User = user
            };

            _studentService.Save(student);

            _studentService.SendSignUp(user, student.Id );

            return student.Id;
        }

        private int CreateTeacher(User user)
        {
            var teacher = new Teacher
            {
                User = user
            };

            _teacherService.Save(teacher);

            return teacher.Id;
        }

        private void DeleteTeacher(int id)
        {
            _teacherService.Delete(id);
        }

        private void DeleteStudent(int id)
        {
            _studentService.Delete(id);
        }

        private int GetTeacherId (int id)
        {
            var t = _teacherService.GetByUser(id);

            return t?.Id ?? 0;
        }

        private int GetStudentId(int id)
        {
            var t = _studentService.GetByUser(id);

            return t?.Id ?? 0;
        }
    }
}