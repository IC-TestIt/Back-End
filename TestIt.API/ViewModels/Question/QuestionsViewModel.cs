using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Question
{
    public class QuestionsViewModel  
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int TestId { get; set; }
        public string Answer { get; set; }
        public virtual List<AlternativeViewModel> Alternatives { get; set; }
    }
}
