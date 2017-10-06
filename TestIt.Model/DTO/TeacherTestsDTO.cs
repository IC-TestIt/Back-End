
using System;
using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.Model.DTO
{
    public class TeacherTestsDTO
    {
        public TeacherTestsDTO()
        {
            ClassTestsApplied = new List<Class>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EnumTestStatus Status { get; set; }
        public IEnumerable<Class> ClassTestsApplied { get; set; }
    }
}