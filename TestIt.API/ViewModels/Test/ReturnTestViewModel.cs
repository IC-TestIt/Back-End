using System.Collections.Generic;

namespace TestIt.API.ViewModels.Test
{
    public class ReturnTestViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Question.FullQuestionViewModel> Questions { get; set; }
    }
}
