using System.Collections.Generic;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Test
{
    public class ReturnTestViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public ICollection<FullQuestionViewModel> Questions { get; set; }
    }
}
