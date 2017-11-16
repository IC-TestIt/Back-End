using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.Model.DTO
{
    public class StudentAnsweredQuestionCorrectionDTO
    {
        public string StudentAnswer { get; set; }
        public int? StudentAlternative { get; set; }
        public string CorrectEssayAnswer { get; set; }
        public string Description { get; set; }
        public IEnumerable<Alternative> Alternatives { get; set; }
        public int Order { get; set; }
    }
}
