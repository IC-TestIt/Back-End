using System;
using AutoMapper;
using System.Linq;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<User.CreateUserViewModel, Model.Entities.User>();
            Mapper.CreateMap<Class.CreateClassViewModel, Model.Entities.Class>();
            Mapper.CreateMap<Test.CreateTestViewModel, Model.Entities.Test>();
            Mapper.CreateMap<Question.BaseQuestionViewModel, Model.Entities.Question>();
            Mapper.CreateMap<Question.CreateEssayQuestionViewModel, EssayQuestion>();
            Mapper.CreateMap<Question.CreateAlternativeQuestionViewModel, AlternativeQuestion>()
                .ForMember(x => x.Alternatives, m => m.MapFrom(x => x.Alternatives.Select(y => new Alternative()
                 {
                     Description = y.Description,
                     IsCorrect = y.IsCorrect
                 }).ToList()));
            Mapper.CreateMap<Log.LogFilterViewModel, Model.Entities.Log>()
                .ForMember(x => x.DateCreated, m => m.MapFrom(x => Convert.ToDateTime(x.DateCreated)));
            Mapper.CreateMap<Exam.CreateExamViewModel, Model.Entities.Exam>();
        }
    }
}
