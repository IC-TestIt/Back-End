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
                         join b in Context.ClassTests on a.Id equals b.TestId
                         join c in Context.Exams on b.Id equals c.ClassTestsId
                         where a.TeacherId == id && c.TotalGrade == 0
                         select new TeacherTestsDTO
                         {
                             Title = a.Title,
                             Description = a.Description,
                             Id = a.Id,
                             Status = EnumTestStatus.Uncorrected
                         }).ToList();

            tests.AddRange(from a in Context.Tests
                           join b in Context.ClassTests on a.Id equals b.TestId
                           join c in Context.Exams on b.Id equals c.ClassTestsId
                           where a.TeacherId == id && c.TotalGrade > 0 
                           select new TeacherTestsDTO
                           {
                               Title = a.Title,
                               Description = a.Description,
                               Id = a.Id,
                               Status = EnumTestStatus.Corrected
                           });

            tests.AddRange(from a in Context.Tests
                           join b in Context.ClassTests on a.Id equals b.TestId
                           where a.TeacherId == id && b.EndDate > DateTime.Now 
                           select new TeacherTestsDTO
                           {
                               Title = a.Title,
                               Description = a.Description,
                               Id = a.Id,
                               Status = EnumTestStatus.Applied
                           });

            tests.AddRange(from a in Context.Tests
                           where a.TeacherId == id && !Context.ClassTests.Any(b=>(b.TestId == a.Id))
                           select new TeacherTestsDTO
                           {
                               Title = a.Title,
                               Description = a.Description,
                               Id = a.Id,
                               Status = EnumTestStatus.notApplied
                           });

            foreach (TeacherTestsDTO tt in tests)
            {
                tt.ClassTestsApplied = (from a in Context.Classes
                                        join b in Context.ClassTests on a.Id equals b.ClassId
                                        join c in Context.Tests on b.TestId equals c.Id
                                        where c.TeacherId == id
                                        select a).ToList();
            }

            return tests;
        }
    }       
}
