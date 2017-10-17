namespace TestIt.API.ViewModels.Question
{
    public class AnsweredQuestionViewModel
    {
        public int Id { get; set; }
        public string EssayAnswer { get; set; }
        public int? AlternativeId { get; set; }
        public int QuestionId { get; set; }
        public int ExamId { get; set; }
        public double Grade { get; set; }
    }
}
