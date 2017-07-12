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

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set; }
            
        public string Identifyer { get; set; }
        public int IdentifyerType { get; set; }
        public SocialId SocialId { get; set; }
        public Organization Organization { get; set; } 
    }
}

