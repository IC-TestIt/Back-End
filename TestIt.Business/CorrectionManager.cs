using System.Collections.Generic;
using System.Linq;
using TestIt.CorrectionAlgorithms;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Business
{
    public class CorrectionManager
    {
        private ExamInformationsDto Exam { get; set; }

        public CorrectionManager(ExamInformationsDto exam)
        {
            Exam = exam;
        }

        public CorrectionDto Correct()
        {
            var correction = new CorrectionDto
            {
                AnsweredQuestions = CorrectAnswers(Exam.AnsweredQuestions.ToList(), Exam.Questions.ToList())
            };

            correction.TotalGrade = correction.AnsweredQuestions.Sum(x => x.Grade);

            return correction;
        }

        private List<AnsweredQuestion> CorrectAnswers(List<AnsweredQuestion> studentAnswers, List<Question> questions)
        {
            studentAnswers.ForEach(answer =>
            {
                var rightAnswer = questions.FirstOrDefault(x => x.Id == answer.QuestionId);

                if (string.IsNullOrEmpty(answer.EssayAnswer))
                {
                    answer.Grade = CorrectAlternative(answer, rightAnswer);
                    answer.Corrected = true;
                }
                else
                {
                    answer.PercentCorrect = CorrectEssay(answer, rightAnswer);
                }
            });

            return studentAnswers;
        }

        private static double CorrectAlternative(AnsweredQuestion answer, Question question)
        {
            var selectedAlternative = question.AlternativeQuestion.Alternatives.FirstOrDefault(x => x.Id == answer.AlternativeId);
            var isCorrect = selectedAlternative != null && selectedAlternative.IsCorrect;

            return isCorrect ? question.Value : 0;
        }

        private double CorrectEssay(AnsweredQuestion answer, Question question)
        {
            double totalPercent;
            var sentencePercent = GetSentencesPercent(answer.EssayAnswer, question.EssayQuestion.Answer);

            if (!string.IsNullOrEmpty(question.EssayQuestion.KeyWords))
            {
                var keyWords = question.EssayQuestion.KeyWords.Split(',').ToList();
                var keyWordPercent = (double)Core.KeyWordMatcher(answer.EssayAnswer, keyWords) / keyWords.Count();

                totalPercent = keyWordPercent * 0.5 + sentencePercent * 0.5;
            }
            else
                totalPercent = sentencePercent;

            return totalPercent;
        }

        private static double GetSentencesPercent(string studentAnswer, string rightAnswer)
        {
            var answerSentences = Core.SeparateIntoSentences(studentAnswer);
            var rightAnswerSentences = Core.SeparateIntoSentences(rightAnswer);

            var sentences = answerSentences.Select(item => new SentenceDto
                {
                    Sentence = item,
                    Value = 0
                })
                .ToList();

            sentences.ForEach(x => x.Value = SetSentenceValue(x.Sentence, rightAnswerSentences.ToArray()));

            return sentences.Average(x => x.Value);
        }

        private static double SetSentenceValue(string sentence, IEnumerable<string> answerSentences)
        {
            return (from teacherSentence in answerSentences let wordsStudent = Core.NormalizeWords(sentence.Split(' ')) let wordsTeacher = Core.NormalizeWords(teacherSentence.Split(' ')) let enumerable = wordsStudent as IList<string> ?? wordsStudent.ToList() let wordsPercentStudentSum = enumerable.Sum(wordStudent => Core.BestTextPercent(wordStudent, wordsTeacher.ToList())) select wordsPercentStudentSum / enumerable.Count).Concat(new[] {0.0}).Max();
        }
    }
}
