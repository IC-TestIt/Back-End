using AutoMapper;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.Exam;
using TestIt.API.ViewModels.Log;
using TestIt.API.ViewModels.Question;
using TestIt.API.ViewModels.Test;
using TestIt.API.ViewModels.User;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Model.Entities.User, ReturnUserViewModel>();
            Mapper.CreateMap<Model.Entities.Test, ReturnTestViewModel>();
            Mapper.CreateMap<Model.Entities.Question, BaseQuestionViewModel>();
            Mapper.CreateMap<Model.Entities.Test, TeacherTestsViewModel>();
            Mapper.CreateMap<Model.Entities.Question, FullQuestionViewModel>()
                .ForMember(x => x.IsAlternative, map => map.MapFrom(x => x.AlternativeQuestion != null))
                .ForMember(x => x.Alternatives, map => map.MapFrom(x => x.AlternativeQuestion != null ? x.AlternativeQuestion.Alternatives : null));
            Mapper.CreateMap<Alternative, AlternativeViewModel>();
            Mapper.CreateMap<AlternativeQuestion, AlternativeQuestionViewModel>();
            Mapper.CreateMap<Model.Entities.Log, ReturnLogViewModel>();
            Mapper.CreateMap<Model.Entities.Class, TeacherClassesViewModel>()
                .ForMember(x => x.Size, map => map.MapFrom(x => x.ClassStudents.Count));
            Mapper.CreateMap<ExamDto, StudentExamsViewModel>();
            Mapper.CreateMap<Model.Entities.Exam, StudentExamsViewModel>();
            Mapper.CreateMap<ExamInformationsDto, ReturnExamViewModel>();
            Mapper.CreateMap<AnsweredQuestion, AnsweredQuestionViewModel>();
            Mapper.CreateMap<StudentTestDto, StudentTestViewModel>();
            Mapper.CreateMap<ClassTests, ClassTestsViewModel>()
                .ForMember(x => x.ClassName, map => map.MapFrom(x => x.Class.Description))
                .ForMember(x => x.TestTitle, map => map.MapFrom(x => x.Test.Title));
            Mapper.CreateMap<TeacherTestsDTO, TeacherTestsViewModel>();
            Mapper.CreateMap<Model.Entities.Class, ReturnClassViewModel>();
        }
    }
}
