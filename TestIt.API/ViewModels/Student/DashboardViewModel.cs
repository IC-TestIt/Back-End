using System.Collections.Generic;
using TestIt.API.ViewModels.ClassStudents;
using TestIt.API.ViewModels.Test;

namespace TestIt.API.ViewModels.Student
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Tests = new List<StudentTestViewModel>();
            Classes = new List<StudentClassViewModel>();
        }

        public IEnumerable<StudentTestViewModel> Tests { get; set; }
        public IEnumerable<StudentClassViewModel> Classes { get; set; }
    }
}
