using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model;

namespace TestIt.Model.Entities
{
    public class Class : IEntityBase
    {
        public Class()
        {
            Students = new List<Student>();
            //MaterialsConsultation = new List<MaterialConsultation>();
        }
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public  String Descricao { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<Student > Students { get; set; }
        //public ICollection<MaterialConsultation> MaterialsConsultation { get; set; }
    }
}
