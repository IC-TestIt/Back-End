using System;
using System.Collections.Generic;

namespace TestIt.API.ViewModels.Class
{
    public class CorrectionClassTestsViewModel
    {
        public CorrectionClassTestsViewModel()
        {
            Ids = new List<int>();
        }

        public IEnumerable<int> Ids { get; set; }
    }
}
