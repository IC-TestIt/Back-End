using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.ClassTest;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassTestsController : Controller
    {
        private readonly ITestService _testService;
        private readonly IClassTestService _classTestService;

        public ClassTestsController(ITestService testService, IClassTestService classTestService)
        {
            _testService = testService;
            _classTestService = classTestService;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateClassTestsViewModel viewModel)
        {
            var classTests = Mapper.Map<UpdateClassTestsViewModel, ClassTests>(viewModel);

            if (_testService.Update(classTests))
            {
                return Ok();
            }

            return Ok(0);
        }

        [HttpGet("{id}/correction")]
        public IActionResult GetCorrected(int id)
        {
            var classTest = _classTestService.GetCorrected(id);

            if(classTest != null)
            {
                //var vm = Mapper.Map<CorrectedClassTestViewModel, CorrectedClassTestViewModel>(classTest);
                
                //return Ok(vm);

            }

            return Ok(0);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(0);
        }
    }
}
