using System;
using System.Collections.Generic;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Exam
{
    public class ReturnExamViewModel
    {
        public ReturnExamViewModel()
        {
            Questions = new List<FullQuestionViewModel>();
            AnsweredQuestions = new List<AnsweredQuestionViewModel>();
        }

        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }

        public IEnumerable<FullQuestionViewModel> Questions { get; set; }
        public IEnumerable<AnsweredQuestionViewModel> AnsweredQuestions { get; set; }
    }
}
