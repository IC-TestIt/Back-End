using System.Collections.Generic;

namespace TestIt.Model.DTO
{
    public class ExamCorrectionDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ExamId { get; set; }
        public int ClassTestId { get; set; }
        public double TotalGrade { get; set; }
        public IEnumerable<AnsweredQuestionDTO> AnsweredQuestions { get; set; }
    }
}
