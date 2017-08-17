using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Question
{
    public class AlternativeQuestionViewModel
    {
        public ICollection<AlternativeViewModel> Alternatives { get; set; }
    }
}
