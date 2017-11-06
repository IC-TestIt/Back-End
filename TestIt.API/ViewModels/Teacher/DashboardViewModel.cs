using System.Collections.Generic;
using TestIt.API.ViewModels.Class;
using TestIt.API.ViewModels.Test;

namespace TestIt.API.ViewModels.Teacher
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            Classes = new List<TeacherClassViewModel>();
            RecentTests = new List<TeacherTestsViewModel>();
        }

        public IEnumerable<TeacherClassViewModel> Classes { get; set; }
        public IEnumerable<TeacherTestsViewModel> RecentTests { get; set; }
    }
}
