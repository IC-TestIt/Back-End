using System.Collections.Generic;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class ExamCorrectionViewModel
    {
        public ExamCorrectionViewModel()
        {
            AnsweredQuestions = new List<CorrectAnsweredQuestionViewModel>();
        }

        public int Id { get; set; }
        public IEnumerable<CorrectAnsweredQuestionViewModel> AnsweredQuestions { get; set; }

    }
}
