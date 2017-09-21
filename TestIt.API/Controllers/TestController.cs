using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateTestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var test = Mapper.Map<Test>(viewModel);

            _testService.Save(test);

            var result = Ok(new { testId = test.Id });

            return result;
        }

        [HttpGet("export/{id}")]
        public IActionResult Index(int id)
        {
            var htmlContent = _testService.ExportTest(id);

            return new OkObjectResult(htmlContent);
        }


        [HttpGet]
        public IActionResult Get()
        {
            var tests = _testService.Get();

            if (tests == null) return NotFound();
            var testsVm = Mapper.Map<IEnumerable<Test>, IEnumerable<ReturnTestViewModel>>(tests);
            return new OkObjectResult(testsVm);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var test = _testService.GetSingle(id);

            if (test == null) return NotFound();
            var testVm = Mapper.Map<Test, ReturnTestViewModel>(test);
            return new OkObjectResult(testVm);
        }

        [HttpPost("{id}/classes")]
        public IActionResult Post(int id, [FromBody] CreateClassTestsViewModel viewModel)
        {
            var classTests = new List<ClassTests>();

            viewModel.ClassIds.ToList().ForEach(cs =>
            {
                var classTest = new ClassTests
                {
                    BeginDate = viewModel.BeginDate,
                    EndDate = viewModel.EndDate,
                    ClassId = cs,
                    TestId = id
                };

                classTests.Add(classTest);
            });

            if (!_testService.Save(classTests)) return Forbid();
            var result = Ok();
            return result;
        }
    }
}
