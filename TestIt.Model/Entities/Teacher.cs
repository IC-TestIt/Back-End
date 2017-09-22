using System;
using System.Collections.Generic;

namespace TestIt.Model.Entities
{
    public class Teacher : IEntityBase
    {
        public Teacher()
        {
            Classes = new List<Class>();
            Tests = new List<Test>();

            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<Class> Classes { get; set; }
        public ICollection<Test> Tests { get; set; }
        
    }
}
