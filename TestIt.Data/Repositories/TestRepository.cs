﻿using System.Linq;
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

        public Test GetForCorrection(int id)
        {
            var questions = (from a in Context.Questions
                             join b in Context.Tests on a.TestId equals b.Id
                             where a.TestId == id
                             select a).Include(x => x.EssayQuestion).Where(x => x.EssayQuestion != null).Include(x => x.Test).OrderBy(x => x.Order).ToList();

            if (questions.Count > 0)
                return questions.FirstOrDefault().Test ?? null;

            return null;
        }

        public IEnumerable<TeacherTestsDTO> GetTeacherTests(int id, int classId = 0)
        {
            var tests = (from a in Context.Tests
                         where a.TeacherId == id
                         select a).ToList();

            var classTests = (from a in Context.ClassTests
                              join b in tests on a.TestId equals b.Id
                              select a).ToList();

            var classes = (from a in Context.Classes
                           where a.TeacherId == id
                           select a).AsQueryable();

            if (classId > 0)
            {
                classes = classes.Where(x => x.Id == classId);
                classTests = classTests.Where(x => x.ClassId == classId).ToList();
            }
            
            var exams = (from a in classTests
                         join b in Context.Exams on a.Id equals b.ClassTestsId
                         select b).ToList();

            var returnTests = new List<TeacherTestsDTO>();
            
            var classesCount = classes.Count();

            var fullClassTests = (from a in classTests
                                  group a by a.TestId into g
                                  where g.Count() >= classesCount
                                  select g).SelectMany(x => x).ToList();

            var notAppliedTests = (from a in tests
                                   where !fullClassTests.Any(x => x.TestId == a.Id)
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
                                                                             .Any(x => x.Status == (int)EnumExamStatus.Finished)
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
                                                                             .All(x => x.Status == (int)EnumExamStatus.Corrected)
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

        public IEnumerable<TeacherTestsDTO> GetTeacherTests(int id, EnumTestStatus status, int n = 0)
        {
            if (status == EnumTestStatus.Uncorrected)
            {
                var tests = (from a in Context.Tests
                             where a.TeacherId == id
                             select a).ToList();

                var classes = (from a in Context.Classes
                               where a.TeacherId == id
                               select a);

                var classTestsQuery = (from a in Context.ClassTests
                                  join b in tests on a.TestId equals b.Id
                                  select a).OrderByDescending(x => x.EndDate).AsQueryable();

                if (n > 0)
                    classTestsQuery = classTestsQuery.Take(n);

                var classTests = classTestsQuery.ToList();

                var exams = (from a in classTests
                             join b in Context.Exams on a.Id equals b.ClassTestsId
                             select b).ToList();

                var notCorrectedTests = (from a in tests
                                         join b in classTests on a.Id equals b.TestId
                                         join c in classes on b.ClassId equals c.Id
                                         where b.EndDate <= DateTime.Now && exams.Where(x => x.ClassTestsId == b.Id)
                                                                                 .Any(x => x.Status == (int)EnumExamStatus.Finished)
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

                return notCorrectedTests;
            }

            return null;
        }
    }       
}
