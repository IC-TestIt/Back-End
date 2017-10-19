using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model.Entities;

namespace TestIt.Model.DTO
{
    public class ExamCorrectionDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ExamId { get; set; }
        public int ClassTestId { get; set; }
        public double TotalGrade { get; set; }
        public IEnumerable<AnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
