using System.Collections.Generic;

namespace TestIt.API.ViewModels.Question
{
    public class StudentAnsweredQuestionCorrectionViewModel
    {
        public string StudentAnswer { get; set; }
        public int? StudentAlternative { get; set; }
        public string CorrectEssayAnswer { get; set; }
        public string Description { get; set; }
        public IEnumerable<AlternativeViewModel> Alternatives { get; set; }
        public int Order { get; set; }
        public double Grade { get; set; }
    }
}
