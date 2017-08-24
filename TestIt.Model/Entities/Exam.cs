using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class Exam : IEntityBase
    {
        public Exam ()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;

            BeginDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Grade { get; set; }
        public int Status { get; set; }


        public Student Student { get; set; }
        public int StudentId { get; set; }

        public ClassTests ClassTests { get; set; }
        public int ClassTestsId { get; set; }
    }
}
