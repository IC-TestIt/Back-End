using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model;
using TestIt.Model.DTO;

namespace TestIt.Business.Services
{
    public class ClassTestService : IClassTestService
    {
        private IClassTestsRepository _classTestRepository;
        private IExamRepository _examRepository;

        public ClassTestService(IClassTestsRepository classTestRepository, IExamRepository examRepository)
        {
            _classTestRepository = classTestRepository;
            _examRepository = examRepository;
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

        private int GetUncorrectedExams(int id)
        {
            return _examRepository.Count(x => x.ClassTestsId == id && x.Status == (int)EnumTestStatus.Uncorrected);
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
