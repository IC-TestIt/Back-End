using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private Business.ITestService testService;

        public TestController(ITestService testService)
        {
            this.testService = testService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateTestViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Test test = Mapper.Map<Test>(viewModel);

            testService.Save(test);

            OkObjectResult result = Ok(new { testId = test.Id });

            return result;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tests = testService.Get();

            if (tests != null)
            {
                IEnumerable<ReturnTestViewModel> testsVm = Mapper.Map<IEnumerable<Test>, IEnumerable<ReturnTestViewModel>>(tests);
                return new OkObjectResult(testsVm);
            }

            return NotFound();

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var test = testService.GetSingle(id);

            if (test != null)
            {
                var testVm = Mapper.Map<Test, ReturnTestViewModel>(test);
                return new OkObjectResult(testVm);
            }
            else
                return NotFound();
        }
        [HttpPost("{id}/classes")]
        public IActionResult Post(int id, [FromBody] CreateClassTestsViewModel viewModel)
        {


            var classTests = new List<ClassTestsDTO>();

            viewModel.ClassIds.ToList().ForEach(x =>
            {
                var classTest = new ClassTestsDTO()
                {
                    BeginDate = viewModel.BeginDate,
                    EndDate = viewModel.EndDate,
                    ClassId = x,
                    TestId = id

                };

                classTests.Add(classTest);
            });

            if (testService.Save(classTests))
            {
               OkResult result = Ok();
               return result;
            }
            else
                return Forbid();

        }

    }
}
