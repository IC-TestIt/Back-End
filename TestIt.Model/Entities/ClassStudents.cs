using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class ClassStudents : IEntityBase
    {
        public ClassStudents()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

    }
}
