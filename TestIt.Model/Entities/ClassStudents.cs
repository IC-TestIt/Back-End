using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class ClassStudents
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
