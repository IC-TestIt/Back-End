using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class AnsweredQuestion : IEntityBase
    {
        public AnsweredQuestion ()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public double Grade { get; set; }
        public string EssayAnswer { get; set; }
        public Alternative Alternative { get; set; }
        public int? AlternativeId { get; set; }

        public Question Question { get; set; }
        public int QuestionId { get; set; }

        public Exam Exam { get; set; }
        public int ExamId { get; set; }
    }
}
