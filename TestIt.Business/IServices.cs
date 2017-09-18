using System.Collections.Generic;
using TestIt.Model.Entities;
using TestIt.Model.DTO;

namespace TestIt.Business
{
    public interface IUserService
    {
        bool ValidLogin(string email, string pswd);
        IEnumerable<User> Get();
        User GetSingle(int id);
        bool Save(User u);
        void Delete(int id);
        bool Update(int id, User u);
        int Exists(string email);
        LoggedUser GetByEmail(string email);
    }

    public interface ITeacherService 
    {
        IEnumerable<Teacher> Get();
        Teacher GetSingle(int id);
        void Save(Teacher t);
        void Delete(int id);
        void Update(int id, Teacher teacher);
        Teacher GetByUser(int id);
    }

    public interface IClassService
    {
        void Save(Class c);
        IEnumerable<User> ClassUsers(int id);
        Class GetSingle(int id);
        IEnumerable<Class> Get();
        IEnumerable<Class> GetTeacherClasses(int id);
        void Delete(int id);
        void DeleteClassTests(int id);
        void DeleteClassStudents(int id);
        void DeleteStudent(int id, int studentId);
    }

    public interface IClassTestsServices { };


    public interface IStudentService
    {
        IEnumerable<Student> Get();
        Student GetSingle(int id);
        void Save(Student s);
        void Delete(int id);
        void Update(int id, Student student);
        Student GetByUser(int id);
        void SendSignUp(User user, int studentId);
        void SendInvite(User user, Class studentClass);
        IEnumerable<StudentTestDTO> Tests(int id);
    }

    public interface IClassStudentsService
    {
        void Save(ClassStudents cs);
        void DeleteStudent(int id, int studentId);
    }

    public interface ITestService
    {
        void Save(Test t);
        void AddQuestion(Question q);
        IEnumerable<Test> Get();
        Test GetSingle(int id);
        IEnumerable<Test> GetTeacherTests(int id);
        bool Save(List<ClassTests> cts);
        string ExportTest(int testId);
    }

    public interface IQuestionService
    {
        void Save(Question q);
        void Save(List<EssayQuestion> q);
        void Save(List<AlternativeQuestion> q);
    }

    public interface ILogService
    {
        void Save(Log l);
        IEnumerable<Log> Filter(Log log);
    }

    public interface IExamService
    {
        void Save(Exam exam);
        IEnumerable<ExamDTO> GetStudentExams(int id);
        bool EndExam(int id, List<AnsweredQuestion> l);
        bool SaveExam(int id, List<AnsweredQuestion> l);
        ExamInformationsDTO Get(int id);
    }
}
