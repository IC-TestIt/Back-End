using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestIt.API.ViewModels.Question;

namespace TestIt.API.ViewModels.Test
{
    public class CorrectionTestViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public ICollection<EssayQuestionViewModel> Questions { get; set; }
    }
}
