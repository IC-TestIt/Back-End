using Org.BouncyCastle.Asn1.Misc;
using TestIt.Model.Entities;

namespace TestIt.API.ViewModels.AnsweredQuestion
{
    public class ReturnAnsweredQuestionViewModel
    {
        public int Id { get; set; }
        public virtual string EssayAnswer { get; set; }
        public virtual Alternative Alternative { get; set; }
        public Model.Entities.Question Question { get; set; }
        public int ExamId { get; set; }
    }
}