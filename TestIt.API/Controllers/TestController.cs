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
        public IEnumerable<Test> Get()
        {
            return testService.Get();

            //if (tests != null)
            //{
            //    IEnumerable<ReturnTestViewModel> usersVm = Mapper.Map<IEnumerable<User>, IEnumerable<ReturnUserViewModel>>(users);
            //    return new OkObjectResult(usersVm);
            //}

            //return NotFound();

        }
    }
}
