using System.Collections.Generic;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class EndExamViewModel 
    {
        public EndExamViewModel(IEnumerable<AnsweredQuestionViewModel> answeredQuestions)
        {
            AnsweredQuestions =  new List<AnsweredQuestionViewModel>(answeredQuestions);

        }
        public IEnumerable<AnsweredQuestionViewModel> AnsweredQuestions { get; set; }
    }
}
