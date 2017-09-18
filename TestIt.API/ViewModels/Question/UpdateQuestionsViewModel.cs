using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Question
{
    public class UpdateQuestionsViewModel
    {
        public UpdateQuestionsViewModel(IEnumerable<QuestionsViewModel> questionsUpdate)
        {
            QuestionsUpdate = new List<QuestionsViewModel>(questionsUpdate);
        }

        public IEnumerable<QuestionsViewModel> QuestionsUpdate { get; set; }

        public IEnumerable<int> questionsRemove { get; set; }
    }
}
