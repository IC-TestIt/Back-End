using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.Question
{
    public class FullQuestionViewModel
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public int TestId { get; set; }
        public virtual AlternativeQuestionViewModel AlternativeQuestion { get; set; }
    }
}
