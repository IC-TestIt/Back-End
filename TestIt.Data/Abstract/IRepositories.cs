using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        List<User> ClassUsers(int classId);
    }
    public interface ITeacherRepository : IEntityBaseRepository<Teacher> {}
    public interface IStudentRepository : IEntityBaseRepository<Student> {}
    public interface IOrganizationRepository : IEntityBaseRepository<Organization> {}
    public interface IClassRepository : IEntityBaseRepository<Class> {}
    public interface IClassStudentsRepository : IEntityBaseRepository<ClassStudents> {}
    public interface ITestRepository : IEntityBaseRepository<Test>
    {
        Test GetFull(int id);    
    }
    public interface IQuestionRepository : IEntityBaseRepository<Question> {}
    public interface IEssayQuestionRepository : IEntityBaseRepository<EssayQuestion> {}
    public interface IAlternativeQuestionRepository : IEntityBaseRepository<AlternativeQuestion> {}
    public interface IAlternativeRepository : IEntityBaseRepository<Alternative> {}
    public interface IClassTestsRepository : IEntityBaseRepository<ClassTests> {}
    public interface ILogRepository : IEntityBaseRepository<Log>
    {
        IEnumerable<Log> Filter(Log log);
    }
}
