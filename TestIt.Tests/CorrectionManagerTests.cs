using System;
using System.Linq;
using Xunit;
using TestIt.CorrectionAlgorithms;
using System.Collections.Generic;
using TestIt.Business;
using TestIt.Model;
using TestIt.Model.Entities;
using TestIt.Model.DTO;

namespace TestIt.Tests
{
    public class CorrectionManagerTests
    {
        [Fact]
        public void CanCorrectTest()
        {
            var alternatives = new List<Alternative>
            {
                new Alternative()
                {
                    AlternativeQuestionId = 1,
                    Id = 1,
                    IsCorrect = false,
                    Description = "2"
                },

                new Alternative()
                {
                    AlternativeQuestionId = 1,
                    Id = 2,
                    IsCorrect = true,
                    Description = "20"
                }
            };

            var questions = new List<Question>
            {
                new Question()
                {
                    Id = 1,
                    TestId = 1,
                    Value = 1,
                    EssayQuestion = new EssayQuestion()
                    {
                        Answer = "Meu nome é Vitor. E eu gosto de git",
                        Id = 1,
                        QuestionId = 1,
                        KeyWords = "Vitor,Git",
                        DateCreated = DateTime.Now.AddDays(-2),
                        DateUpdated = DateTime.Now.AddDays(-2),
                    },
                    Description = "Qual seu nome e hobbie?",
                    DateCreated = DateTime.Now.AddDays(-2),
                    DateUpdated = DateTime.Now.AddDays(-2)
                },

                new Question()
                {
                    Id = 2,
                    TestId = 1,
                    Value = 1,
                    AlternativeQuestion = new AlternativeQuestion()
                    {
                        DateCreated = DateTime.Now.AddDays(-2),
                        DateUpdated = DateTime.Now.AddDays(-2),
                        Id = 1,
                        QuestionId = 2,
                        Alternatives = alternatives
                    },
                    Description = "",
                    DateCreated = DateTime.Now.AddDays(-2),
                    DateUpdated = DateTime.Now.AddDays(-2)
                }
            };

            var answeredQuestions = new List<AnsweredQuestion>
            {
                new AnsweredQuestion()
                {
                    AlternativeId = 2,
                    ExamId = 1,
                    Id = 1,
                    QuestionId = 2
                },

                new AnsweredQuestion()
                {
                    EssayAnswer = "Meu nome é gitor. e eu gosto de git",
                    Id = 2,
                    QuestionId = 1,
                    ExamId = 1
                }
            };

            var exam = new ExamInformationsDTO()
            {
                Id = 1,
                Title = "Prova Teste",
                BeginDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now,
                Status = (int)EnumStatus.Finished,
                TestId = 1,
                Questions = questions,
                AnsweredQuestions = answeredQuestions
            };

            var manager = new CorrectionManager(exam);
            
            var actualCorrection = manager.Correct();
            Assert.Equal(1, actualCorrection.TotalGrade);

            var gradeQuestion1 = actualCorrection.AnsweredQuestions.FirstOrDefault(x => x.QuestionId == 1).PercentCorrect;
            Assert.Equal(0.73958333333333337, gradeQuestion1);

            var valueQuestion2 = actualCorrection.AnsweredQuestions.FirstOrDefault(x => x.QuestionId == 2).Grade;
            Assert.Equal(1, valueQuestion2);

        }
    }
}
