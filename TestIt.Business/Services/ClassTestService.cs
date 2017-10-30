using System;
using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;

namespace TestIt.Business.Services
{
    public class ClassTestService : IClassTestService
    {
        private IClassTestsRepository _classTestRepository;

        public ClassTestService(IClassTestsRepository classTestRepository)
        {
            _classTestRepository = classTestRepository;
        }

        public CorrectedClassTestDTO GetCorrected(int id)
        {
            var students = GetClassStudents(id);

            var classTest = new CorrectedClassTestDTO()
            {
                ClassAverageGrade = GetClassGrade(students),
                Questions = GetClassTestQuestions(id),
                Students = students
            };

            return classTest;
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
        
    }
}
