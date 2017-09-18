using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Test;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassTestsController : Controller
    {
        private ITestService _testService;

        public ClassTestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateClassTestsViewModel viewModel)
        {
            var classTests = Mapper.Map<UpdateClassTestsViewModel, ClassTests>(viewModel);

            if (_testService.Update(classTests))
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
