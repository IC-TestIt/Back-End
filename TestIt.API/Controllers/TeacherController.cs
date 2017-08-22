using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Class;
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
        private IClassService classService;

        public TeacherController(ITeacherService teacherService, IUserService userService, 
                                                ITestService testService, IClassService classService)
        {
            this.teacherService = teacherService;
            this.userService = userService;
            this.testService = testService;
            this.classService = classService;
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
        [HttpGet("{id}/classes")]
        public IActionResult GetTeacherClasses(int id)
        {
            var classes = classService.GetTeacherClasses(id);

            if (classes != null)
            {
                IEnumerable<TeacherClassesViewModel> classesVm = Mapper.Map<IEnumerable<Class>, IEnumerable<TeacherClassesViewModel>>(classes);
                return new OkObjectResult(classesVm);
            }

            return NotFound();
        }



    }
}
