using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using System.Linq;

namespace TestIt.Business.Services
{
    public class TestService : ITestService
    {
        private ITestRepository testRepository;
        private IClassTestsRepository classTestsRepository;

        public TestService(ITestRepository testRepository, IClassTestsRepository classTestsRepository)
        {
            this.testRepository = testRepository;
            this.classTestsRepository = classTestsRepository;

        }
        public void Save(Test t)
        {
            testRepository.Add(t);
            testRepository.Commit();
        }

        public void AddQuestion(Question q)
        {
            var test = testRepository.GetSingle(q.TestId);
            test.Questions.Add(q);
            testRepository.Update(test);
            testRepository.Commit();
        }

        public IEnumerable<Test> Get()
        {
            return testRepository.AllIncluding(x => x.Questions);
        }
  
        public Test GetSingle(int id)
        {
            return testRepository.GetFull(id);
        }

        public IEnumerable<Test> GetTeacherTests(int id)
        {
            var tests = testRepository.FindBy(x => x.TeacherId == id);
            return tests; 
        }

        public bool Save(List<ClassTests> cts)
        {
            if (cts.All(x => !Exists(x.ClassId, x.TestId)))
            {
                classTestsRepository.AddMultiple(cts);
                classTestsRepository.Commit();
                return true;
            }
            else
                return false;
        }

        public bool Exists(int classId, int testId)
        {
            return  classTestsRepository.Any(x => x.ClassId  == classId && x.TestId == testId);
        }

        public string ExportTest(int testId)
        {
            var test = GetSingle(testId);
            string html = BuildHeader(test) + AddQuestions(test.Questions) + BuildFooter();

            return html;
        }

        public string BuildHeader(Test test)
        {
            string html = "<html><head><meta charset='utf-8'></head><body style='font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;'>";

            html += "<h1 style='text-align: center; font-size: 16px;'>" + test.Title + "</h1>" + "<h2 style='text-align: center; font-size: 14px;'>" + test.Description + "</h2>";
            html += "<p style='margin: 30px 0; font-size: 14px; '>Nome: <hr /></p>";
            html += "<p style='margin-top: 30px; margin-bottom: 50px; font-size: 14px; '>Data: ____/____/______</p>";

            return html;
        }

        public string AddQuestions(ICollection<Question> questions)
        {
            string html = "";
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

        public string BuildFooter()
        {
            return "</body></html>";
        }

    }
}