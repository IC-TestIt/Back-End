using AutoMapper;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Entities.User, User.ReturnUserViewModel>();
            Mapper.CreateMap<Model.Entities.Test, Test.ReturnTestViewModel>();
            Mapper.CreateMap<Model.Entities.Question, Question.BaseQuestionViewModel>();
            Mapper.CreateMap<Model.Entities.Test, Test.TeacherTestsViewModel>();
            Mapper.CreateMap<Model.Entities.Question, Question.FullQuestionViewModel>()
                .ForMember(x => x.IsAlternative, map => map.MapFrom(x => x.AlternativeQuestion != null))
                .ForMember(x => x.Alternatives, map => map.MapFrom(x => x.AlternativeQuestion != null ? x.AlternativeQuestion.Alternatives : null));
            Mapper.CreateMap<Alternative, Question.AlternativeViewModel>();
            Mapper.CreateMap<AlternativeQuestion, Question.AlternativeQuestionViewModel>();
            Mapper.CreateMap<Model.Entities.Log, Log.ReturnLogViewModel>();
        }
    }
}
