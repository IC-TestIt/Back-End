using System;

namespace TestIt.Model.DTO
{
    public class StudentTestDto
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public DateTime EndDate { get; set; }
        public int ClassTestId { get; set; }
    }
}
