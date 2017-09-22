using System;
using System.Collections.Generic;

namespace TestIt.Model.Entities
{
    public class Test : IEntityBase
    {
        public Test()
        {
            Questions = new List<Question>();
            ClassTests = new List<ClassTests>();

            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<ClassTests> ClassTests { get; set; }
    }
}
