using System;
using System.Collections.Generic;
using System.Text;
using TestIt.CorrectionAlgorithms;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using System.Linq;
using TestIt.Model;

namespace TestIt.Business
{
    public class CorrectionManager
    {
        private ExamInformationsDTO Exam { get; set; }

        public CorrectionManager(ExamInformationsDTO exam)
        {
            Exam = exam;
        }

        public CorrectionDTO Correct()
        {
            var correction = new CorrectionDTO()
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
                }
                else
                {
                    answer.PercentCorrect = CorrectEssay(answer, rightAnswer);
                }
            });

            return studentAnswers;
        }

        private double CorrectAlternative(AnsweredQuestion answer, Question question)
        {
            var selectedAlternative = question.AlternativeQuestion.Alternatives.FirstOrDefault(x => x.Id == answer.AlternativeId);
            var isCorrect = selectedAlternative.IsCorrect;

            return isCorrect ? question.Value : 0;
        }

        private double CorrectEssay(AnsweredQuestion answer, Question question)
        {
            var totalPercent = 0.0;
            var sentencePercent = GetSentencesPercent(answer.EssayAnswer, question.EssayQuestion.Answer);

            if (!string.IsNullOrEmpty(question.EssayQuestion.KeyWords))
            {
                var keyWords = question.EssayQuestion.KeyWords.Split(',').ToList();
                var keyWordPercent = Core.KeyWordMatcher(answer.EssayAnswer, keyWords) / keyWords.Count();

                totalPercent = keyWordPercent * 0.7 + sentencePercent * 0.3;
            }
            else
                totalPercent = sentencePercent;

            return totalPercent;
        }

        private double GetSentencesPercent(string studentAnswer, string rightAnswer)
        {
            var sentences = new List<SentenceDTO>();

            var answerSentences = Core.SeparateIntoSentences(studentAnswer);
            var rightAnswerSentences = Core.SeparateIntoSentences(rightAnswer);

            foreach (var item in answerSentences)
            {
                sentences.Add(new SentenceDTO()
                {
                    Sentence = item,
                    Value = 0
                });
            }

            sentences.ForEach(x => x.Value = SetSentenceValue(x.Sentence, rightAnswerSentences.ToArray()));

            return sentences.Average(x => x.Value);
        }

        private double SetSentenceValue(string sentence, string[] answerSentences)
        {
            var words = sentence.Split(' ');
            var bestMatch = 0.0;
            
            return bestMatch;
        }
    }
}
