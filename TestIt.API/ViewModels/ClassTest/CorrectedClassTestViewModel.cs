using System.Collections.Generic;

namespace TestIt.API.ViewModels.ClassTest
{
    public class CorrectedClassTestViewModel : BaseClassTestViewModel
    {
        public CorrectedClassTestViewModel()
        {
            Students = new List<ClassTestStudentViewModel>();
            Questions = new List<ClassTestQuestionsViewModel>();
        }

        public double ClassAverageGrade { get; set; }

        public IEnumerable<ClassTestStudentViewModel> Students { get; set; }
        public IEnumerable<ClassTestQuestionsViewModel> Questions { get; set; }
    }
}
