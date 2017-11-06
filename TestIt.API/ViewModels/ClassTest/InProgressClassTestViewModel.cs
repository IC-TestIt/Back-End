using System.Collections.Generic;

namespace TestIt.API.ViewModels.ClassTest
{
    public class InProgressClassTestViewModel : BaseClassTestViewModel
    {
        public InProgressClassTestViewModel()
        {
            Students = new List<ClassTestStudentViewModel>();
        }

        public int UncorrectedExams { get; set; }

        public IEnumerable<ClassTestStudentViewModel> Students { get; set; }
    }
}
