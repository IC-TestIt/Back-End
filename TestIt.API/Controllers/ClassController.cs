using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Mappings;
using TestIt.API.ViewModels.Class;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        private Business.IClassService classService;

        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }

        [HttpPost]
        public void Post([FromBody]CreateClassViewModel viewModel)
        {
            Class newClass = Mapper.Map<Class>(viewModel);

            classService.Save(newClass);
        }


    }
}
