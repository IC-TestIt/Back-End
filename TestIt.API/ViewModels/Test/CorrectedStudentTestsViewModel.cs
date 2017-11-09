using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Test
{
    public class CorrectedStudentTestsViewModel
    {
        public int TestId { get; set; }
        public string Description { get; set; }
        public int ClassTestId { get; set; }
        public int ExamId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Grade { get; set; }

    }
}
