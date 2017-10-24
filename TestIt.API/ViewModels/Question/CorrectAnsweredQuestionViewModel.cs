namespace TestIt.API.ViewModels.Question
{
    public class CorrectAnsweredQuestionViewModel
    {   
        public int Id { get; set; }
        public string StudentAnswer { get; set; }
        public double PercentCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
