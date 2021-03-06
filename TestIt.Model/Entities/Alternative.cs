﻿using System;
using System.Collections.Generic;

namespace TestIt.Model.Entities
{
    public class Alternative : IEntityBase
    {
        public Alternative()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;

            AnsweredQuestions = new List<AnsweredQuestion>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        public int AlternativeQuestionId { get; set; }
        public AlternativeQuestion AlternativeQuestion { get; set; }
        public IEnumerable<AnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
