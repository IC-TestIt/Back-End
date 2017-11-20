using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model;
using TestIt.Model.DTO;
using TestIt.Utils.Email;
using TestIt.Utils;

namespace TestIt.Business.Services
{
    public class ClassTestService : IClassTestService
    {
        private IClassTestsRepository _classTestRepository;
        private IExamRepository _examRepository;
        private IEmailService _emailService;
        private IClassRepository _classRepository;

        public ClassTestService(IClassTestsRepository classTestRepository, IExamRepository examRepository, 
                                IEmailService emailService, IClassRepository classRepository)
        {
            _classTestRepository = classTestRepository;
            _examRepository = examRepository;
            _emailService = emailService;
            _classRepository = classRepository;
        }

        public CorrectedClassTestDTO GetCorrected(int id)
        {
            var students = GetClassStudents(id);
            var bs = GetBaseClassTest(id);

            var classTest = new CorrectedClassTestDTO()
            {
                ClassAverageGrade = GetClassGrade(students),
                Questions = GetClassTestQuestions(id),
                Students = students,
                BeginDate = bs.BeginDate,
                Title = bs.Title,
                EndDate = bs.EndDate,
                ClassName = bs.ClassName
            };

            return classTest;
        }

        public InProgressClassTestDTO GetInProgress(int id)
        {
            var bs = GetBaseClassTest(id);

            var classTest = new InProgressClassTestDTO()
            {
                BeginDate = bs.BeginDate,
                ClassName = bs.ClassName,
                EndDate = bs.EndDate,
                Title = bs.Title,
                Students = GetClassStudents(id),
                UncorrectedExams = GetUncorrectedExams(id)
            };

            return classTest;
        }

        public bool PublishGrade(int id)
        {
            var classTest = _classTestRepository.SingleIncluding(id, x => x.Class, y => y.Test);

            if (classTest == null)
                return false;

            classTest.IsPublished = true;
            if (_classTestRepository.Commit() == 0)
                return false;
            
            var emailList = GetClassEmails(id);
            var testName = classTest.Test.Title + " - " + classTest.Class.Description;
            var email = PublishClassTestEmailBuilder(testName);

            _emailService.Send(email, emailList);

            return true;
        }

        private IEnumerable<string> GetClassEmails(int classId)
        {
            var emails = _classRepository.GetStudentsEmails(classId);

            return emails;
        }

        private Email PublishClassTestEmailBuilder(string testName)
        {
            var email = new Email()
            {
                BodyContent = "A nota da prova: " + testName + 
                              " já está disponível em: " + Consts.ClientUrl,
                Subject = "TestIt - Nota Disponível"
            };

            return email;
        }

        private int GetUncorrectedExams(int id)
        {
            return _examRepository.Count(x => x.ClassTestsId == id && x.Status == (int)EnumExamStatus.Finished);
        }

        private double GetClassGrade(IEnumerable<ClassTestStudentDTO> students)
        {
            return students.Average(x => x.Grade);
        }

        private IEnumerable<ClassTestStudentDTO> GetClassStudents(int id)
        {
            return _classTestRepository.GetStudents(id);
        }

        private IEnumerable<ClassTestQuestionsDTO> GetClassTestQuestions(int id)
        {
            return _classTestRepository.GetClassTestQuestions(id);
        }

        private BaseClassTestDTO GetBaseClassTest(int id)
        {
            return _classTestRepository.GetBaseClassTest(id);
        }
    }
}
