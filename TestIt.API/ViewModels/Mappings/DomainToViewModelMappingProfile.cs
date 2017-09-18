using AutoMapper;
using TestIt.Model.Entities;
using TestIt.Model.DTO;

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
            Mapper.CreateMap<Model.Entities.Class, Class.TeacherClassesViewModel>()
                .ForMember(x => x.Size, map => map.MapFrom(x => x.ClassStudents.Count));
            Mapper.CreateMap<ExamDTO, Exam.StudentExamsViewModel>();
            Mapper.CreateMap<Model.Entities.Exam, Exam.StudentExamsViewModel>();
            Mapper.CreateMap<ExamInformationsDTO, Exam.ReturnExamViewModel>();
            Mapper.CreateMap<AnsweredQuestion, Question.AnsweredQuestionViewModel>();
            Mapper.CreateMap<StudentTestDTO, Test.StudentTestViewModel>();
            Mapper.CreateMap<ClassTests, Class.ClassTestsViewModel>()
                .ForMember(x => x.ClassName, map => map.MapFrom(x => x.Class.Description))
                .ForMember(x => x.TestTitle, map => map.MapFrom(x => x.Test.Title));
        }
    }
}
