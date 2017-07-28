using AutoMapper;
using TestIt.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using TestIt.API.ViewModels;

namespace TestIt.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Entities.User, User.ReturnUserViewModel>();
            Mapper.CreateMap<Model.Entities.Test, Test.ReturnTestViewModel>();
        }
    }
}
