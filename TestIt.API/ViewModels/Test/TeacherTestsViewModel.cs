using System.Collections.Generic;
using TestIt.API.ViewModels.Class;
using TestIt.Model;


namespace TestIt.API.ViewModels.Test
{
    public class TeacherTestsViewModel
    {
        public TeacherTestsViewModel()
        {
            ClassTestsApplied = new List<ReturnClassViewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumTestStatus Status { get; set; }
        public IEnumerable<ReturnClassViewModel> ClassTestsApplied { get; set; }
    }
}
