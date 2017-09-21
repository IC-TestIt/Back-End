using System;
using System.Collections.Generic;

namespace TestIt.Model.Entities
{
    public class Exam : IEntityBase
    {
        public Exam ()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;

            Status = (int)EnumStatus.Started;
            BeginDate = DateTime.Now;

            AnsweredQuestions = new List<AnsweredQuestion>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalGrade { get; set; }
        public int Status { get; set; }


        public Student Student { get; set; }
        public int StudentId { get; set; }

        public ClassTests ClassTests { get; set; }
        public int ClassTestsId { get; set; }

        public IEnumerable<AnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
