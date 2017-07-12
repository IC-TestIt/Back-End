using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model;

namespace TestIt.Model.Entities
{
    public class Organization : IEntityBase
    {
        public Organization()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
