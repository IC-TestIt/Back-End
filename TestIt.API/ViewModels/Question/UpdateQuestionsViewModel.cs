using System.Collections.Generic;

namespace TestIt.API.ViewModels.Question
{
    public class UpdateQuestionsViewModel
    {
        public UpdateQuestionsViewModel(IEnumerable<QuestionsViewModel> questionsUpdate)
        {
            QuestionsUpdate = new List<QuestionsViewModel>(questionsUpdate);
        }

        public IEnumerable<QuestionsViewModel> QuestionsUpdate { get; set; }

        public IEnumerable<int> QuestionsRemove { get; set; }
    }
}
