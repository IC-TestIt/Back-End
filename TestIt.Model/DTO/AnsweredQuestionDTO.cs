namespace TestIt.Model.DTO
{
    public class AnsweredQuestionDTO
    {
        public int Id { get; set; }
        public string StudentAnswer { get; set; }
        public double PercentCorrect { get; set; }
        public int QuestionId { get; set; }
        public bool Corrected { get; set; }
    }
}
