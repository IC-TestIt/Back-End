using System.Collections.Generic;

namespace TestIt.API.ViewModels.Class
{
    public class TeacherClassesViewModel
    {
        public TeacherClassesViewModel()
        {
            Classes = new List<TeacherClassViewModel>();
        }

        public int TotalClasses { get; set; }

        public TeacherClassViewModel BestClass { get; set; }
        public TeacherClassViewModel WorseClass { get; set; }

        public IEnumerable<TeacherClassViewModel> Classes { get; set; }
    }
}
