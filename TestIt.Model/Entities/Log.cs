using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Model.Entities
{
    public class Log : IEntityBase
    {
        public Log ()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }

        public int Id { get ; set ; }
        public DateTime DateCreated { get ; set ; }
        public DateTime DateUpdated { get ; set ; }

        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
    }
}
