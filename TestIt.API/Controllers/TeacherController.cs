﻿using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.Model.DTO;
using TestIt.API.ViewModels.Teacher;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ITestService _testService;
        private readonly IClassService _classService;

        public TeacherController(ITeacherService teacherService, ITestService testService, IClassService classService)
        {
            _teacherService = teacherService;
            _testService = testService;
            _classService = classService;
        }

        [HttpGet("{id}/tests")]
        public IActionResult GetTeacherTests(int id)
        {
            var tests = _testService.GetTeacherTests(id);

            if (tests == null) return Ok(0);
            var testsVm = Mapper.Map<IEnumerable<TeacherTestsDTO>, IEnumerable<TeacherTestsViewModel>>(tests);
            return new OkObjectResult(testsVm);
        }

        [HttpGet("{id}/classes")]
        public IActionResult GetTeacherClasses(int id)
        {
            var teacherClasses = _classService.GetTeacherClasses(id);

            if (teacherClasses == null) return Ok(0);
            var classesVm = Mapper.Map<TeacherClassesDTO, TeacherClassesViewModel>(teacherClasses);
            return new OkObjectResult(classesVm);
        }

        [HttpGet("{id}/appliedTests")]
        public IActionResult GetTeacherClassTests(int id)
        {
            var classTests = _teacherService.GetClassTests(id);

            if (classTests == null) return Ok(0);
            var classTestsVm = Mapper.Map<IEnumerable<ClassTests>,IEnumerable<ClassTestsViewModel>>(classTests);

            return Ok(classTestsVm);
        }

        [HttpGet("{id}/dashboard")]
        public IActionResult GetTeacherDashboardData(int id)
        {
            var data = _teacherService.GetDashboard(id);

            if (data == null) return Ok(0);
            var vm = Mapper.Map<DashboardDTO, DashboardViewModel>(data);

            return Ok(vm);
        }
    }
}
