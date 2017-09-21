using System;
using System.Collections.Generic;

namespace TestIt.Model.Entities
{
    public class Student : IEntityBase
    {
        public Student()
        {
            ClassStudents = new List<ClassStudents>();

            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public IEnumerable<ClassStudents> ClassStudents { get; set; }
        public IEnumerable<Exam> Exams { get; set; }

    }
}
