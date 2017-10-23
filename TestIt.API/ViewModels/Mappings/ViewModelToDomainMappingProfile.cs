using System;
using System.Linq;
using AutoMapper;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.Exam;
using TestIt.API.ViewModels.Log;
using TestIt.API.ViewModels.Question;
using TestIt.API.ViewModels.Test;
using TestIt.API.ViewModels.User;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<CreateUserViewModel, Model.Entities.User>();
            Mapper.CreateMap<CreateClassViewModel, Model.Entities.Class>();
            Mapper.CreateMap<CreateTestViewModel, Model.Entities.Test>();
            Mapper.CreateMap<BaseQuestionViewModel, Model.Entities.Question>();
            Mapper.CreateMap<CreateEssayQuestionViewModel, EssayQuestion>();
            Mapper.CreateMap<CreateAlternativeQuestionViewModel, AlternativeQuestion>()
                .ForMember(x => x.Alternatives, m => m.MapFrom(x => x.Alternatives.Select(y => new Alternative
                {
                     Description = y.Description,
                     IsCorrect = y.IsCorrect
                 }).ToList()));
            Mapper.CreateMap<LogFilterViewModel, Model.Entities.Log>()
                .ForMember(x => x.DateCreated, m => m.MapFrom(x => Convert.ToDateTime(x.DateCreated)));
            Mapper.CreateMap<CreateExamViewModel, Model.Entities.Exam>();
            Mapper.CreateMap<EndExamViewModel, Model.Entities.Exam>();
            Mapper.CreateMap<AnsweredQuestionViewModel, AnsweredQuestion>();
            Mapper.CreateMap<QuestionsViewModel, Model.Entities.Question>();
            Mapper.CreateMap<QuestionsViewModel, EssayQuestion>()
                .ForMember(x => x.Id, m => m.MapFrom(x => x.EssayQuestionId))
                .ForMember(x => x.QuestionId, m => m.MapFrom(x => x.Id));
            Mapper.CreateMap<QuestionsViewModel, AlternativeQuestion>()
                .ForMember(x => x.Id, m => m.MapFrom(x => x.AlternativeQuestionId))
                .ForMember(x => x.QuestionId, m => m.MapFrom(x => x.Id))
                .ForMember(x => x.Alternatives, m => m.MapFrom(x => x.Alternatives.Select(y => new Alternative
                {
                    Description = y.Description,
                    IsCorrect = y.IsCorrect
                 }).ToList()));
            Mapper.CreateMap<UpdateClassTestsViewModel, ClassTests>();
            Mapper.CreateMap<UpdateQuestionsViewModel, Model.Entities.Question>();
            Mapper.CreateMap<ExamCorrectionViewModel, Model.Entities.Exam>();
        }
    }
}
