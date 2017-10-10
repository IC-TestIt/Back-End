
using System;
using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.Model.DTO
{
    public class TeacherTestsDTO
    {
        public int TestId { get; set; }
        public int ClassTestId { get; set; }
        public string TestTitle { get; set; }
        public string ClassName { get; set; }
        public DateTime BeginDate { get; set; }
        public EnumTestStatus Status { get; set; }
    }
}