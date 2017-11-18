using System;

namespace TestIt.Model.DTO
{
    public class StudentTestDTO
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public DateTime EndDate { get; set; }
        public int ClassTestId { get; set; }
        public int TestId { get; set; }
        public EnumTestStatus Status { get; set; }
    }
}
