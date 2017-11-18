using System.Collections.Generic;

namespace TestIt.Model.DTO
{
    public class ClassDTO
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ClassTestStudentDTO> Students { get; set; }
        public IEnumerable<TeacherTestsDTO> Tests { get; set; }
    }
}
