using System.Collections.Generic;
using TestIt.Model;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        IEnumerable<User> ClassUsers(int classId);
    }
    public interface ITeacherRepository : IEntityBaseRepository<Teacher> {}
    public interface IStudentRepository : IEntityBaseRepository<Student>
    {
        IEnumerable<StudentTestDTO> GetTests(int id);
    }
    public interface IOrganizationRepository : IEntityBaseRepository<Organization> {}
    public interface IClassRepository : IEntityBaseRepository<Class>
    {
        IEnumerable<TeacherClassDTO> GetTeacherClasses(int id);
        IEnumerable<string> GetStudentsEmails(int classId);
        ClassDTO GetDetails(int id);
    }
    public interface IClassStudentsRepository : IEntityBaseRepository<ClassStudents>
    {
        IEnumerable<StudentClassDTO> GetClasses(int id);
    }
    public interface ITestRepository : IEntityBaseRepository<Test>
    {
        Test GetFull(int id);
        Test GetForCorrection(int id);
        IEnumerable<TeacherTestsDTO> GetTeacherTests(int id, int classId = 0);
        IEnumerable<TeacherTestsDTO> GetTeacherTests(int id, EnumTestStatus status, int n = 0);
    }
    public interface IQuestionRepository : IEntityBaseRepository<Question> {}
    public interface IEssayQuestionRepository : IEntityBaseRepository<EssayQuestion> {}
    public interface IAlternativeQuestionRepository : IEntityBaseRepository<AlternativeQuestion> {}
    public interface IAlternativeRepository : IEntityBaseRepository<Alternative> {}
    public interface IClassTestsRepository : IEntityBaseRepository<ClassTests>
    {
        IEnumerable<ClassTestQuestionsDTO> GetClassTestQuestions(int id);
        IEnumerable<ClassTestStudentDTO> GetStudents(int id);
        BaseClassTestDTO GetBaseClassTest(int id);
    }
    public interface ILogRepository : IEntityBaseRepository<Log>
    {
        IEnumerable<Log> Filter(Log log);
    }
    public interface IExamRepository : IEntityBaseRepository<Exam>
    {
        IEnumerable<ExamDto> GetExams(int id);
        ExamInformationsDto GetFull(int id);
        IEnumerable<ExamCorrectionDTO> GetForCorrection(int classTestId);
        StudentExamCorrectionDTO GetStudentCorrection(int id);
    }
    public interface IAnsweredQuestionRepository : IEntityBaseRepository<AnsweredQuestion>
    {
        int CorrectQuestions(int id, IEnumerable<AnsweredQuestion> questions);
        int AnswerQuestions(int examId, IEnumerable<AnsweredQuestion> questions);
    }
}
