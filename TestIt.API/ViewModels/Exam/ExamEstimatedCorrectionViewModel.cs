using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class ExamEstimatedCorrectionViewModel
    {
        public ExamEstimatedCorrectionViewModel()
        {
           AnsweredQuestions = new List<CorrectAnsweredQuestionViewModel>();
        }
        public int ExamId { get; set; }
        public string StudentName { get; set; }
        public double TotalGrade { get; set; }
        public int ClassTestsId { get; set; }
        public int StudentId { get; set; }

      public IEnumerable<CorrectAnsweredQuestionViewModel> AnsweredQuestions { get; set; }
    }
}
