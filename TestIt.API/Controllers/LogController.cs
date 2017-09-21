using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Log;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService) => _logService = logService;

        [HttpPost("filter")]
        public IActionResult Post([FromBody] LogFilterViewModel vm)
        {
            var filter = Mapper.Map<LogFilterViewModel, Log>(vm);

            var logs = _logService.Filter(filter);

            if (logs == null)
                return NotFound();

            var logVm = Mapper.Map<IEnumerable<Log>, IEnumerable<ReturnLogViewModel>>(logs);
            return new OkObjectResult(logVm);
        }

         

    }
}
