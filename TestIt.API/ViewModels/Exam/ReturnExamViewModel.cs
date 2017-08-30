using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Exam
{
    public class ReturnExamViewModel
    {
        public int StudentId { get; set; }
        public int ClassTestsId { get; set; }
        public ICollection<AnsweredQuestion.ReturnAnsweredQuestionViewModel> AnsweredQuestions { get; set; }
    }
}