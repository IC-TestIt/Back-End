using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestIt.Model.DTO
{
    public class TeacherClassDTO
    {
        public string Description { get; set; }
        public int Size { get; set; }
        public int Id { get; set; }
        public double Average { get; set; }
        public bool HasTests { get; set; }
    }
}