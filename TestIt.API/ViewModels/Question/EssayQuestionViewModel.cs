using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Question
{
    public class EssayQuestionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
    }
}
