using AutoMapper;

namespace TestIt.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {

            //Mapper.CreateMap<ScheduleViewModel, Schedule>()
            //   .ForMember(s => s.Creator, map => map.UseValue(null))
            //   .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

            //Mapper.CreateMap<UserViewModel, User>();
            Mapper.CreateMap<User.CreateUserViewModel, Model.Entities.User>();
            Mapper.CreateMap<Class.CreateClassViewModel, Model.Entities.Class>();
        }
    }
}
