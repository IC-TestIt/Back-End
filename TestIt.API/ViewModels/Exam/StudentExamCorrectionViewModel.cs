using System.Collections.Generic;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class StudentExamCorrectionViewModel
    {
        public StudentExamCorrectionViewModel()
        {
            Answers = new List<StudentAnsweredQuestionCorrectionViewModel>();
        }

        public string Description { get; set; }
        public string ClassName { get; set; }
        public int StudentId { get; set; }
        public int ClassTestId { get; set; }
        public IEnumerable<StudentAnsweredQuestionCorrectionViewModel> Answers { get; set; } 
    }
}
