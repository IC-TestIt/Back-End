using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model;

namespace TestIt.Model.Entities
{
    public class User : IEntityBase
    {

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Phone { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set; }

        public int IdentifyerType { get; set; }
        public SocialId SocialId { get; set; }
        public Organization Organization { get; set; } 
    }
}

