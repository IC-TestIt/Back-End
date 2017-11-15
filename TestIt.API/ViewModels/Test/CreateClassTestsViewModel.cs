using System;
using System.Collections.Generic;

namespace TestIt.API.ViewModels.Test
{
    public class CreateClassTestsViewModel 
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<int> ClassIds { get; set; }
    }
}
