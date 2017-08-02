using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private ITeacherService teacherService;
        private IUserService userService;
        private ITestService testService;

        public TeacherController(ITeacherService teacherService, IUserService userService, ITestService testService)
        {
            this.teacherService = teacherService;
            this.userService = userService;
            this.testService = testService;
        }

        [HttpGet("{id}/tests")]
        public IActionResult GetTeacherTests(int id)
        {
            var teacher = teacherService.GetSingle(id);

            if(teacher != null)
            {
                var tests = testService.GetTeacherTests(id);

                if (tests != null)
                {
                    IEnumerable<TeacherTestsViewModel> testsVm = Mapper.Map<IEnumerable<Test>, IEnumerable<TeacherTestsViewModel>>(tests);
                    return new OkObjectResult(testsVm);
                }

            }

            return NotFound();
        }


    }
}
