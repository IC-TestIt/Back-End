using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class AnsweredQuestionRepository : EntityBaseRepository<AnsweredQuestion>, IAnsweredQuestionRepository
    {
        public AnsweredQuestionRepository(TestItContext context)
            : base(context)
        { }

        public int CorrectQuestions(int id, IEnumerable<AnsweredQuestion> questions)
        {
            var obj = new List<AnsweredQuestion>();

            foreach(var question in questions)
            {
                var entity = Context.AnsweredQuestions.FirstOrDefault(x => x.Id == question.Id);
                var questionValue = Context.Questions.Where(x => x.Id == entity.QuestionId).Select(x => x.Value).FirstOrDefault();

                entity.Grade = question.Grade * questionValue;
                entity.Corrected = question.Corrected;

                obj.Add(entity);
            }

            var exam = Context.Exams.FirstOrDefault(x => x.Id == id);

            exam.TotalGrade = obj.Sum(x => x.Grade);
            exam.Status = (int)EnumExamStatus.Corrected;

            return Context.SaveChanges();
        }

        public int AnswerQuestions(int examId, IEnumerable<AnsweredQuestion> questions)
        {
            var obj = new List<AnsweredQuestion>();

            foreach(var question in questions)
            {
                var entity = Context.AnsweredQuestions.FirstOrDefault(x => x.ExamId == examId && x.QuestionId == question.QuestionId);

                entity.AlternativeId = question.AlternativeId;
                entity.EssayAnswer = question.EssayAnswer;

                obj.Add(entity);
            }

            return Context.SaveChanges();
        }
    }
}
