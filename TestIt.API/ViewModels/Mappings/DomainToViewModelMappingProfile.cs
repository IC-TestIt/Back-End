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
            Mapper.CreateMap<Model.Entities.Question, Question.FullQuestionViewModel>();
            Mapper.CreateMap<Alternative, Question.AlternativeViewModel>();
            Mapper.CreateMap<AlternativeQuestion, Question.AlternativeQuestionViewModel>();
        }
    }
}
