using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using TestIt.Model;
using System.Linq;
using System;

namespace TestIt.Data.Repositories
{
    public class ClassRepository : EntityBaseRepository<Class>, IClassRepository
    {
        public ClassRepository(TestItContext context)
            : base(context)
        { }

        public IEnumerable<string> GetStudentsEmails(int classId)
        {
            var emails = (from a in Context.ClassStudents
                          join b in Context.Students on a.StudentId equals b.Id
                          join c in Context.Users on b.UserId equals c.Id
                          where a.ClassId == classId
                          select c.Email).ToList();

            return emails;
        }

        public IEnumerable<TeacherClassDTO> GetTeacherClasses(int id)
        {
            var classes = (from a in Context.Classes
                           join b in Context.ClassTests on a.Id equals b.ClassId
                           join c in Context.Exams on b.Id equals c.ClassTestsId
                           join d in Context.ClassStudents on a.Id equals d.ClassId
                           where a.TeacherId == id
                           select new
                           {
                               Id = a.Id,
                               Description = a.Description,
                               TotalGrade = c.TotalGrade,
                               StudentId = d.Id
                           }).Distinct();

            var classesWithoutTests = (from a in Context.Classes
                                       join c in Context.ClassTests on a.Id equals c.ClassId into ps
                                       from f in ps.DefaultIfEmpty()
                                       where a.TeacherId == id && f == null
                                       select new TeacherClassDTO
                                       {
                                           Average = 0,
                                           Description = a.Description,
                                           Id = a.Id,
                                           Size = Context.ClassStudents.Count(x => x.ClassId == a.Id)
                                       }).ToList();

            var list = (from a in classes
                        group a by a.Id into g
                        select new TeacherClassDTO()
                        {
                            Id = g.FirstOrDefault().Id,
                            Description = g.FirstOrDefault().Description,
                            Average = g.Average(x => x.TotalGrade),
                            Size = g.GroupBy(x => x.StudentId).Count()
                           
                        }).OrderByDescending(x => x.Average).ToList();

            list.AddRange(classesWithoutTests.Distinct());

            return list;
        }

        public ClassDTO GetDetails(int id)
        {
            var details = new ClassDTO();

            var classObj = (from a in Context.Classes
                            where a.Id == id
                            select new
                            {
                                Name = a.Description,
                                TeacherId = a.TeacherId
                            }).FirstOrDefault();

            details.Name = classObj.Name;
            details.TeacherId = classObj.TeacherId;
            
            var grades = (from a in Context.ClassTests
                          join b in Context.Exams on a.Id equals b.ClassTestsId
                          where a.ClassId == id
                          select new
                          {
                              TotalGrade = b.TotalGrade,
                              StudentId = b.StudentId
                          }).ToList();
            
            details.Students = (from a in Context.ClassStudents
                                join b in Context.Students on a.StudentId equals b.Id
                                join c in Context.Users on b.UserId equals c.Id
                                where a.ClassId == id
                                select new ClassTestStudentDTO
                                {
                                    StudentId = b.Id,
                                    StudentIdentifier = c.Identifier,
                                    StudentName = c.Name,
                                }).Distinct().ToList();

            foreach(var student in details.Students)
            {
                var studentGrades = (from d in grades
                                     where d.StudentId == student.StudentId
                                     select d.TotalGrade).ToList();
                student.Grade = studentGrades.Any() ? studentGrades.Average() : 0;
            }

            return details;
        }
    }
}