using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Log;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        private ILogService logService;

        public LogController(ILogService logService)
        {
            this.logService = logService;
        }

        [HttpGet("{date}{class}{method}")]
        public IActionResult Filter(Log log)
        {
            IEnumerable<Log> logs = logService.Filter(log);

            if (logs != null)
            {
                IEnumerable<ReturnLogViewModel> logVm = Mapper.Map<IEnumerable<Log>, IEnumerable<ReturnLogViewModel>>(logs);
                return new OkObjectResult(logVm);
            }

            return NotFound();
        }

         

    }
}
