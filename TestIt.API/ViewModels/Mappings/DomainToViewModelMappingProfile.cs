using AutoMapper;
using TestIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestIt.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            //Mapper.CreateMap<Schedule, ScheduleViewModel>()
            //   .ForMember(vm => vm.Creator,
            //        map => map.MapFrom(s => s.Creator.Name))
            //   .ForMember(vm => vm.Attendees, map =>
            //        map.MapFrom(s => s.Attendees.Select(a => a.UserId)));
        }
    }
}
