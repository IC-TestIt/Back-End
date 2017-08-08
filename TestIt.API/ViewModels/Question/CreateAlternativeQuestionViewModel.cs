using System.Collections.Generic;
using System.Linq;

namespace TestIt.API.ViewModels.Question
{
    public class CreateAlternativeQuestionViewModel : BaseQuestionViewModel
    {
        public ICollection<AlternativeViewModel> Alternatives { get; set; }
    }
}
