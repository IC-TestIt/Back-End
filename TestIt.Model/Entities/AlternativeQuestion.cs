using System;
using System.Collections.Generic;

namespace TestIt.Model.Entities
{
    public class AlternativeQuestion : IEntityBase
    {
        public AlternativeQuestion()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;

            Alternatives = new List<Alternative>();
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        
        public ICollection<Alternative> Alternatives { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
