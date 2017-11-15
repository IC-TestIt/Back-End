using System.Collections.Generic;
using System.Linq;
using TestIt.Data.Abstract;
using TestIt.Model;
using TestIt.Model.DTO;
using TestIt.Model.Entities;

namespace TestIt.Data.Repositories
{
    public class ClassTestsRepository : EntityBaseRepository<ClassTests>, IClassTestsRepository
    {
        public ClassTestsRepository(TestItContext context)
            : base(context)
        { }

        public IEnumerable<ClassTestStudentDTO> GetStudents(int id)
        {
            var students = (from a in Context.Exams
                            join b in Context.Students on a.StudentId equals b.Id
                            join c in Context.Users on b.UserId equals c.Id
                            where a.ClassTestsId == id
                            select new ClassTestStudentDTO()
                            {
                                Grade = a.TotalGrade,
                                StudentIdentifier = c.Identifier,
                                StudentName = c.Name,
                                StudentId = b.Id,
                                Status = a.Status
                            }).ToList();

            var absentStudents = (from a in Context.ClassStudents
                                  join b in Context.Students on a.StudentId equals b.Id
                                  join c in Context.Users on b.UserId equals c.Id
                                  join d in Context.ClassTests on a.ClassId equals d.ClassId
                                  join e in Context.Exams on d.Id equals e.ClassTestsId into ps
                                  from f in ps.DefaultIfEmpty()
                                  where d.Id == id
                                  select new ClassTestStudentDTO()
                                  {
                                      Grade = 0,
                                      Status = (int)EnumStudentStatus.Absent,
                                      StudentIdentifier = c.Identifier,
                                      StudentId = b.Id,
                                      StudentName = c.Name
                                  });

            students.AddRange(absentStudents);
            
            return students.GroupBy(x => x.StudentId).Select(x => x.FirstOrDefault());
        }

        public IEnumerable<ClassTestQuestionsDTO> GetClassTestQuestions(int id)
        {
            var questions = (from a in Context.Exams
                             join b in Context.AnsweredQuestions on a.Id equals b.ExamId
                             join c in Context.Questions on b.QuestionId equals c.Id
                             where a.ClassTestsId == id && b.Corrected
                             select new ClassTestQuestionsDTO()
                             {
                                 QuestionId = b.QuestionId,
                                 QuestionOrder = c.Order,
                                 ClassAverage = b.Grade
                             });

            var list = (from a in questions
                        group a by a.QuestionId into g
                        select new ClassTestQuestionsDTO()
                        {
                            QuestionId = g.FirstOrDefault().QuestionId,
                            QuestionOrder = g.FirstOrDefault().QuestionOrder,
                            ClassAverage = g.Average(x => x.ClassAverage)
                        }).ToList();

            return list;
        }

        public BaseClassTestDTO GetBaseClassTest(int id)
        {
            var baseClassTest = (from a in Context.ClassTests
                                 join b in Context.Tests on a.TestId equals b.Id
                                 join c in Context.Classes on a.ClassId equals c.Id
                                 where a.Id == id
                                 select new BaseClassTestDTO()
                                 {
                                     BeginDate = a.BeginDate,
                                     EndDate = a.EndDate,
                                     ClassName = c.Description,
                                     Title = b.Title,
                                     ClassTestId = a.Id
                                 });

            return baseClassTest.FirstOrDefault();
        }
    }
}
