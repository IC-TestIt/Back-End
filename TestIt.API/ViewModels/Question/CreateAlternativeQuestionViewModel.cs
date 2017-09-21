using System.Collections.Generic;

namespace TestIt.API.ViewModels.Question
{
    public class CreateAlternativeQuestionViewModel : BaseQuestionViewModel
    {
        public ICollection<AlternativeViewModel> Alternatives { get; set; }
    }
}
