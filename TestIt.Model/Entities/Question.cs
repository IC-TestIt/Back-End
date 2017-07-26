using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class Question : IEntityBase
    {
        public Question()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Answer { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }
    }
}
