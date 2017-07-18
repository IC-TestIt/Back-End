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
        private Business.IClassStudentsService classStudentService;

        public ClassController(IClassService classService, IClassStudentsService classStudentService)
        {
            this.classService = classService;
            this.classStudentService = classStudentService;
        }

        [HttpPost]
        public void Post([FromBody]CreateClassViewModel viewModel)
        {
            Class newClass = Mapper.Map<Class>(viewModel);

            classService.Save(newClass);
        }

        [HttpPost("{id}/student/{studentId}")]
        public void Post(int id, int studentId)
        {
            classStudentService.Save(new ClassStudents()
            {
                ClassId = id,
                StudentId = studentId
            });
        }
    }
}
