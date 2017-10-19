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
           AnsweredQuestions = new List<AnsweredQuestionViewModel>();

        }
 
        public int ExamId { get; set; }
        public string StudentName { get; set; }
        public double TotalGrade { get; set; }
        public int ClassTestsId { get; set; }
        public int StudentId { get; set; }
        public IEnumerable<AnsweredQuestionViewModel> AnsweredQuestions { get; set; }
    }
}
