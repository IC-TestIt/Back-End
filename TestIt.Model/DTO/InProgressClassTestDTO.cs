using System.Collections.Generic;

namespace TestIt.Model.DTO
{
    public class InProgressClassTestDTO : BaseClassTestDTO
    {
        public InProgressClassTestDTO()
        {
            Students = new List<ClassTestStudentDTO>();
        }

        public int UncorrectedExams { get; set; }

        public IEnumerable<ClassTestStudentDTO> Students { get; set; }
    }
}
