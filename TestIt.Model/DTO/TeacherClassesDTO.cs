using System.Collections.Generic;


namespace TestIt.Model.DTO
{
    public class TeacherClassesDTO
    {
        public TeacherClassesDTO()
        {
            Classes = new List<TeacherClassDTO>();
        }

        public int TotalClasses { get; set; }

        public TeacherClassDTO BestClass { get; set; }
        public TeacherClassDTO WorseClass { get; set; }

        public IEnumerable<TeacherClassDTO> Classes { get; set; }

    }
}