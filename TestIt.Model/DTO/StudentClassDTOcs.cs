using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestIt.Model.DTO
{
    public class StudentClassDTO
    {
        public StudentClassDTO()
        {
            CorrectedStudentTests = new List<CorrectedStudentTestsDTO>();
        }

        public int ClassId { get; set; }
        public string Description { get; set; }
        public string TeacherName { get; set; }

        public IEnumerable<CorrectedStudentTestsDTO> CorrectedStudentTests { get; set; }
    }
}