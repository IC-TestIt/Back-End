using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class ClassTests : IEntityBase
    {
        public ClassTests ()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }


        public int  ClassId { get; set; }
        public Class Class { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
