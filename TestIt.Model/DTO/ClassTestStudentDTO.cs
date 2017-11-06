using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.DTO
{
    public class ClassTestStudentDTO : ClassTestBaseStudentDTO
    {
        public int Status { get; set; }
        public double Grade { get; set; }
    }
}
