using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model;

namespace TestIt.Model.Entities
{
    public class Teacher : IEntityBase
    {
        public Teacher()
        {
            Classes = new List<Class>();

            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<Class> Classes { get; set; }
        
    }
}
