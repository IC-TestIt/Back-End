using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Test
{
    public class StudentTestViewModel
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public DateTime EndDate { get; set; }
        public int ClassTestId { get; set; }
    }
}
