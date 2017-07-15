using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestIt.API.ViewModels.Mappings;
using TestIt.API.ViewModels.User;
using TestIt.Business;
using TestIt.Model.Entities;

namespace TestIt.API.Controllers
{
    public class UserController : Controller
    {
        private Business.IUserService userService;
        private Business.ITeacherService teacherService;

        public UserController(IUserService userService, ITeacherService teacherService)
        {
            this.userService = userService;
            this.teacherService = teacherService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userService.Get();
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userService.GetSingle(id);
        }

        [HttpPost]
        public void Post([FromBody]CreateUserViewModel viewModel)
        {
            User user = Mapper.Map<User>(viewModel);
            userService.Save(user);            
            if(viewModel.Type == 1) 
            {
                Teacher t = new Teacher();
                t.User = user;

                teacherService.Save(t);
            }
            else 
            {

            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CreateUserViewModel viewModel)
        {
            User user = Mapper.Map<User>(viewModel);
            userService.Update(id, user);            
        }

        [HttpDelete("{id?type}")]
        public void Delete(int id, int type)
        {
            User user = userService.GetSingle(id);
            if(type == 1) 
            {
                Teacher t = teacherService.GetByUser(id);
                teacherService.Delete(t.Id);
            }
            userService.Delete(id);
            
        }
    }
}