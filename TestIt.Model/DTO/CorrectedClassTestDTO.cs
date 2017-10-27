using System.Collections.Generic;

namespace TestIt.Model.DTO
{
    public class CorrectedClassTestDTO
    {
        public CorrectedClassTestDTO()
        {
            Students = new List<ClassTestStudentDTO>();
            Questions = new List<ClassTestQuestionsDTO>();
        }

        public double ClassAverageGrade { get; set; }

        public IEnumerable<ClassTestStudentDTO> Students { get; set; }
        public IEnumerable<ClassTestQuestionsDTO> Questions { get; set; }
    }
}
