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
                           where a.TeacherId == id
                           select a);

            var exams = (from a in classTests
                         join b in Context.Exams on a.Id equals b.ClassTestsId
                         select b).ToList();

            var returnTests = new List<TeacherTestsDTO>();
            
            var classesCount = classes.Count();

            var notFullClassTests = (from a in classTests
                                     group a by a.ClassId into g
                                     where g.Count() < classesCount
                                     select g).SelectMany(x => x);

            var notAppliedTests = (from a in tests
                                   where !notFullClassTests.Any(x => x.TestId == a.Id)
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
                                    EndDate = b.EndDate,
                                    Status = EnumTestStatus.Applied
                                }).ToList();

            var notCorrectedTests = (from a in tests
                                     join b in classTests on a.Id equals b.TestId
                                     join c in classes on b.ClassId equals c.Id
                                     where b.EndDate <= DateTime.Now && exams.Where(x => x.ClassTestsId == b.Id)
                                                                             .Any(x => x.Status == (int)EnumStatus.Finished)
                                     select new TeacherTestsDTO
                                     {
                                         TestId = a.Id,
                                         ClassName = c.Description,
                                         ClassTestId = b.Id,
                                         TestTitle = a.Title,
                                         BeginDate = b.BeginDate,
                                         EndDate = b.EndDate,
                                        Status = EnumTestStatus.Uncorrected
                                     }).ToList();

            var correctedTests = (from a in tests
                                  join b in classTests on a.Id equals b.TestId
                                  join c in classes on b.ClassId equals c.Id
                                  where b.EndDate <= DateTime.Now && exams.Where(x => x.ClassTestsId == b.Id)
                                                                             .All(x => x.Status == (int)EnumStatus.Corrected)
                                  select new TeacherTestsDTO
                                  {
                                      TestId = a.Id,
                                      ClassName = c.Description,
                                      ClassTestId = b.Id,
                                      TestTitle = a.Title,
                                      BeginDate = b.BeginDate,
                                      EndDate = b.EndDate,
                                      Status = EnumTestStatus.Corrected
                                  }).ToList();
            
            returnTests.AddRange(appliedTests);
            returnTests.AddRange(notCorrectedTests);
            returnTests.AddRange(correctedTests);

            returnTests = returnTests.GroupBy(x => x.ClassTestId).Select(x => x.First()).ToList();

            returnTests.AddRange(notAppliedTests);

            return returnTests;
        }
    }       
}
