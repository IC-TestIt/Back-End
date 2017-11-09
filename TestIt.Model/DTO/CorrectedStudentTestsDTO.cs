using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestIt.Model.DTO
{
    public class CorrectedStudentTestsDTO
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