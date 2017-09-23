using System.Collections.Generic;

namespace TestIt.API.ViewModels.Question
{
    public class FullQuestionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int TestId { get; set; }
        public bool IsAlternative { get; set; }
        public int Order { get; set; }
        public virtual List<AlternativeViewModel> Alternatives { get; set; }
    }
}
