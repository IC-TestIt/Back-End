using System.Collections.Generic;

namespace TestIt.API.ViewModels.Question
{
    public class AlternativeQuestionViewModel
    {
        public ICollection<AlternativeViewModel> Alternatives { get; set; }
    }
}
