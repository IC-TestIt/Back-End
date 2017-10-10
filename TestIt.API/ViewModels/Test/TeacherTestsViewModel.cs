using System;
using TestIt.Model;

namespace TestIt.API.ViewModels.Test
{
    public class TeacherTestsViewModel
    {
        public int TestId { get; set; }
        public int ClassTestId { get; set; }
        public string TestTitle { get; set; }
        public string ClassName { get; set; }
        public DateTime BeginDate { get; set; }
        public EnumTestStatus Status { get; set; }
    }
}
