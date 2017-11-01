using System.Collections.Generic;


namespace TestIt.Model.DTO
{
    public class TeacherClassesDTO
    {
        public TeacherClassesDTO()
        {
            Classes = new List<TeacherClassDTO>();
        }

        public IEnumerable<TeacherClassDTO> Classes { get; set; }

    }
}