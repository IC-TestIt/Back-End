using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;
using TestIt.Model.DTO;
using System.Collections.Generic;
using TestIt.Model;
using System;

namespace TestIt.Data.Repositories
{
    public class TestRepository : EntityBaseRepository<Test>, ITestRepository
    {
        public TestRepository(TestItContext context)
            : base(context)
        {
        }

        public Test GetFull(int id)
        {
            var question = (from a in Context.Questions
                        join b in Context.Tests on a.TestId equals b.Id
                        where a.TestId == id
                        select a).Include(x => x.EssayQuestion).Include(x => x.Test).Include(x => x.AlternativeQuestion.Alternatives).OrderBy(x => x.Order).ToList();

            return question.FirstOrDefault().Test ?? null;
        }

        public IEnumerable<TeacherTestsDTO> GetTeacherTests(int id)
        {
            var tests = (from a in Context.Tests
                         where a.TeacherId == id
                         select a).ToList();

            var classTests = (from a in Context.ClassTests
                              join b in tests on a.TestId equals b.Id
                              select a).ToList();

            var classes = (from a in Context.Classes
                           join b in classTests on a.Id equals b.ClassId
                           select a);

            var exams = (from a in classTests
                         join b in Context.Exams on a.Id equals b.ClassTestsId
                         select b).ToList();

            var returnTests = new List<TeacherTestsDTO>();

            var notAppliedTests = (from a in tests
                                   where !classTests.Any(b => (b.TestId == a.Id))
                                   select new TeacherTestsDTO
                                   {
                                       TestId = a.Id,
                                       TestTitle = a.Title,
                                       Status = EnumTestStatus.NotApplied
                                   }).ToList();

            var appliedTests = (from a in tests
                                join b in classTests on a.Id equals b.TestId
                                join c in classes on b.ClassId equals c.Id
                                where b.EndDate > DateTime.Now
                                select new TeacherTestsDTO
                                {
                                    TestId = a.Id,
                                    ClassName = c.Description,
                                    ClassTestId = b.Id,
                                    TestTitle = a.Title,
                                    BeginDate = b.BeginDate,
                                    Status = EnumTestStatus.Applied
                                }).ToList();

            var notCorrectedTests = (from a in tests
                                     join b in classTests on a.Id equals b.TestId
                                     join c in classes on b.ClassId equals c.Id
                                     where b.EndDate <= DateTime.Now
                                     select new TeacherTestsDTO
                                     {
                                        TestId = a.Id,
                                        ClassName = c.Description,
                                        ClassTestId = b.Id,
                                        TestTitle = a.Title,
                                        BeginDate = b.BeginDate,
                                        Status = EnumTestStatus.Uncorrected
                                     }).ToList();
            
            var correctedTests = (from a in tests
                                  join b in classTests on a.Id equals b.TestId
                                  join c in classes on b.ClassId equals c.Id
                                  join d in exams on b.Id equals d.ClassTestsId
                                  where b.EndDate <= DateTime.Now && d.TotalGrade > 0
                                  select new TeacherTestsDTO
                                  {
                                      TestId = a.Id,
                                      ClassName = c.Description,
                                      ClassTestId = b.Id,
                                      TestTitle = a.Title,
                                      BeginDate = b.BeginDate,
                                      Status = EnumTestStatus.Corrected
                                  }).ToList();

            returnTests.AddRange(notAppliedTests);
            returnTests.AddRange(appliedTests);
            returnTests.AddRange(notCorrectedTests);
            returnTests.AddRange(correctedTests);

            returnTests = returnTests.GroupBy(x => x.ClassTestId).Select(x => x.First()).ToList();

            return returnTests;
        }
    }       
}
