using System.Collections.Generic;

namespace TestIt.Model.DTO
{
    public class StudentExamCorrectionDTO
    {
        public StudentExamCorrectionDTO()
        {
            Answers = new List<StudentAnsweredQuestionCorrectionDTO>();
        }

        public string Description { get; set; }
        public string ClassName { get; set; }
        public int StudentId { get; set; }
        public int ClassTestId { get; set; }
        public IEnumerable<StudentAnsweredQuestionCorrectionDTO> Answers { get; set; }
    }
}
