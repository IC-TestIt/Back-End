using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.Model.DTO
{
    public class CorrectionDto
    {
        public double TotalGrade { get; set; }
        public List<AnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
