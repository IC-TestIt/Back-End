using System.Collections.Generic;

namespace TestIt.API.ViewModels.Class
{
    public class TeacherClassesViewModel
    {
        public TeacherClassesViewModel()
        {
            Classes = new List<TeacherClassViewModel>();
        }

        public IEnumerable<TeacherClassViewModel> Classes { get; set; }
    }
}
