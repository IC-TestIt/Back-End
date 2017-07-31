using System;

namespace TestIt.Model.Entities
{
    public class Alternative : IEntityBase
    {
        public Alternative()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Description { get; set; }

        public int AlternativeQuestionId { get; set; }
        public AlternativeQuestion AlternativeQuestion { get; set; }
        public AlternativeQuestion SecondAlternativeQuestion { get; set; }
    }
}
