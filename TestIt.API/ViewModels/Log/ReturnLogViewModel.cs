using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestIt.API.ViewModels.Log
{
    public class ReturnLogViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
    }
}
