using System.Collections.Generic;

namespace TestIt.Model.DTO
{
    public class DashboardDTO
    {
        public DashboardDTO()
        {
            Classes = new List<TeacherClassDTO>();
            RecentTests = new List<TeacherTestsDTO>();
        }

        public IEnumerable<TeacherClassDTO> Classes { get; set; }
        public IEnumerable<TeacherTestsDTO> RecentTests { get; set; }
    }
}
