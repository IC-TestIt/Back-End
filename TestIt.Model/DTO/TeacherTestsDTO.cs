using System;

namespace TestIt.Model.DTO
{
    public class TeacherTestsDTO
    {
        public int TestId { get; set; }
        public int ClassTestId { get; set; }
        public string TestTitle { get; set; }
        public string ClassName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public EnumTestStatus Status { get; set; }
    }
}