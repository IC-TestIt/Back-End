using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class CorrectedExamViewModel
    {
        public CorrectedExamViewModel()
        {
           AnsweredQuestions = new List<CorrectAnsweredQuestionViewModel>();
        }
 
        public int Id { get; set; }
        public IEnumerable<CorrectAnsweredQuestionViewModel> AnsweredQuestions { get; set; } 
                                                                                
    }
}
