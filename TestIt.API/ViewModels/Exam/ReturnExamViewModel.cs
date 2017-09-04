using System;
using System.Collections.Generic;

namespace TestIt.API.ViewModels.Exam
{
    public class ReturnExamViewModel
    {
        public ReturnExamViewModel()
        {
            Questions = new List<Question.FullQuestionViewModel>();
            AnsweredQuestions = new List<Question.AnsweredQuestionViewModel>();
        }

        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }

        public IEnumerable<Question.FullQuestionViewModel> Questions { get; set; }
        public IEnumerable<Question.AnsweredQuestionViewModel> AnsweredQuestions { get; set; }
    }
}
