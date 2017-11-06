using AutoMapper;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.ClassTest;
using TestIt.API.ViewModels.Exam;
using TestIt.API.ViewModels.Log;
using TestIt.API.ViewModels.Question;
using TestIt.API.ViewModels.Teacher;
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
            Mapper.CreateMap<Model.DTO.TeacherClassDTO, TeacherClassViewModel>();
            Mapper.CreateMap<Model.DTO.TeacherClassesDTO, TeacherClassesViewModel>();
            Mapper.CreateMap<ExamDto, StudentExamsViewModel>();
            Mapper.CreateMap<Model.Entities.Exam, StudentExamsViewModel>();
            Mapper.CreateMap<ExamInformationsDto, ReturnExamViewModel>();
            Mapper.CreateMap<AnsweredQuestion, AnsweredQuestionViewModel>();
            Mapper.CreateMap<StudentTestDto, StudentTestViewModel>();
            Mapper.CreateMap<ClassTests, ClassTestsViewModel>()
                .ForMember(x => x.ClassName, map => map.MapFrom(x => x.Class.Description))
                .ForMember(x => x.TestTitle, map => map.MapFrom(x => x.Test.Title));
            Mapper.CreateMap<TeacherTestsDTO, TeacherTestsViewModel>();
            Mapper.CreateMap<ClassTestsDTO, ReturnClassViewModel>();
            Mapper.CreateMap<ExamCorrectionDTO, ClassTestsEstimatedCorrectionViewModel>();
            Mapper.CreateMap<Model.Entities.Test, ClassTestsEstimatedCorrectionViewModel>();
            Mapper.CreateMap<Model.Entities.Test, CorrectionTestViewModel>();
            Mapper.CreateMap<ExamCorrectionDTO, ExamEstimatedCorrectionViewModel>();
            Mapper.CreateMap<Model.Entities.Question, EssayQuestionViewModel>()
                .ForMember(x => x.Answer, map => map.MapFrom(x => x.EssayQuestion.Answer));
            Mapper.CreateMap<AnsweredQuestionDTO, CorrectAnsweredQuestionViewModel>();
            Mapper.CreateMap<CorrectedClassTestDTO, CorrectedClassTestViewModel>();
            Mapper.CreateMap<BaseClassTestDTO, BaseClassTestViewModel>();
            Mapper.CreateMap<ClassTestBaseStudentDTO, ClassTestBaseStudentViewModel>();
            Mapper.CreateMap<ClassTestStudentDTO, ClassTestStudentViewModel>();
            Mapper.CreateMap<ClassTestQuestionsDTO, ClassTestQuestionsViewModel>();
            Mapper.CreateMap<InProgressClassTestDTO, InProgressClassTestViewModel>();
            Mapper.CreateMap<DashboardDTO, DashboardViewModel>();
        }
    }
}
