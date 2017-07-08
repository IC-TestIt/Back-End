﻿using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model;

namespace TestIt.Model.Entities
{
    public class Student : IEntityBase
    {
        public Student()
        {
            Classes = new List<Class>();
            //Exams = new List<Exam>;
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public User User { get; set; }
        public int IdUser { get; set; }

        public ICollection<Class> Classes { get; set; }
        //public ICollection<Exam> Exams { get; set; }
    }
}
