using System;

namespace TestIt.Model.DTO
{
    public class BaseClassTestDTO
    {
        public string Title { get; set; }
        public string ClassName { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClassTestId { get; set; }
    }
}