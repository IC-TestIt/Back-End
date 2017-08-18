using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.Business;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller 
    {
        private IStudentService studentService;
        private IUserService userService;

        public StudentController(IStudentService studentService, IUserService userService)
        {
            this.studentService = studentService;
            this.userService = userService;
        }

        [HttpGet("exists/{email}")]
        public IActionResult StudentExists(string email)
        {
            var userId = userService.Exists(email);

            if (userId == 0)
            {
                return NotFound(1);
            }

            var result = new OkObjectResult(studentService.GetByUser(userId).Id);
            return result;
        }
    }
}
