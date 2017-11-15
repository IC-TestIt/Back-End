using System;

namespace TestIt.Model.Entities
{
    public class EssayQuestion : IEntityBase
    {
        public EssayQuestion()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        
        public string Answer { get; set; }
        public string KeyWords { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
