using System;

namespace TestIt.API.ViewModels.Class
{
    public class ClassTestsViewModel
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ClassName { get; set; }
        public string TestTitle { get; set; }
    }
}
