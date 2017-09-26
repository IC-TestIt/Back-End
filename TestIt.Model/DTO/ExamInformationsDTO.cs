using System;
using System.Collections.Generic;
using TestIt.Model.Entities;

namespace TestIt.Model.DTO
{
    public class ExamInformationsDto
    {
        public ExamInformationsDto()
        {
            Questions = new List<Question>();
            AnsweredQuestions = new List<AnsweredQuestion>();
        }

        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public int TestId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }

        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<AnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
