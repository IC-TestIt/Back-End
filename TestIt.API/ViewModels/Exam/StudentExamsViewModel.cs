using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Exam
{
    public class StudentExamsViewModel
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalGrade { get; set; }
        public int Status { get; set; }
        public int ClassTestsId { get; set; }

    }
}
