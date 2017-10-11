using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IClassTestsRepository _classTestsRepository;

        public TestService(ITestRepository testRepository, IClassTestsRepository classTestsRepository)
        {
            _testRepository = testRepository;
            _classTestsRepository = classTestsRepository;

        }
        public void Save(Test t)
        {
            _testRepository.Add(t);
            _testRepository.Commit();
        }

        public void AddQuestion(Question q)
        {
            var test = _testRepository.GetSingle(q.TestId);
            test.Questions.Add(q);
            _testRepository.Update(test);
            _testRepository.Commit();
        }

        public IEnumerable<Test> Get()
        {
            return _testRepository.AllIncluding(x => x.Questions);
        }
  
        public Test GetSingle(int id)
        {
            return _testRepository.GetFull(id);
        }

        public IEnumerable<TeacherTestsDTO> GetTeacherTests(int id)
        {
            var tests = _testRepository.GetTeacherTests(id);
            return tests; 
        }

        public bool Save(List<ClassTests> cts)
        {
            if (cts.Any(x => Exists(x.ClassId, x.TestId))) return false;
            _classTestsRepository.AddMultiple(cts);
            _classTestsRepository.Commit();
            return true;
        }

        public bool Update(ClassTests cts)
        {
            if (!_classTestsRepository.Any(x => x.Id == cts.Id))
                return false;

            _classTestsRepository.Update(cts);
            return true;
        }

        private bool Exists(int classId, int testId)
        {
            return  _classTestsRepository.Any(x => x.ClassId  == classId && x.TestId == testId);
        }

        public string ExportTest(int testId)
        {
            var test = GetSingle(testId);
            var html = BuildHeader(test) + AddQuestions(test.Questions) + BuildFooter();

            return html;
        }

        private static string BuildHeader(Test test)
        {
            var html = "<html><head><meta charset='utf-8'></head><body style='font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;'>";

            html += "<h1 style='text-align: center; font-size: 16px;'>" + test.Title + "</h1>" + "<h2 style='text-align: center; font-size: 14px;'>" + test.Description + "</h2>";
            html += "<p style='margin: 30px 0; font-size: 14px; '>Nome: <hr /></p>";
            html += "<p style='margin-top: 30px; margin-bottom: 50px; font-size: 14px; '>Data: ____/____/______</p>";

            return html;
        }

        private static string AddQuestions(IEnumerable<Question> questions)
        {
            var html = "";
            var number = 1;
            foreach (var question in questions)
            {
                html += "<p style='margin: 25px 0; font-size: 13px;'>" + "Questão " + number + " : " + question.Description + "</p>";
                if (question.AlternativeQuestion != null)
                {
                    var index = 0;
                    string[] labels = { "(A)", "(B)", "(C)", "(D)", "(E)" };
                    foreach (var alternative in question.AlternativeQuestion.Alternatives)
                    {
                        html += "<p style='font-size: 12px;'>" + labels.ElementAt(index) + " " + alternative.Description + "</p>";
                        index++;
                    }
                }
                if (question.EssayQuestion != null)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        html += "<hr style='margin-bottom: 25px;'>";
                    }
                }
                number++;
            }

            return html;
        }

        private static string BuildFooter()
        {
            return "</body></html>";
        }

    }
}