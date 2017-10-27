using System;
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
                                      StudentName = c.Name
                                  });

            students.AddRange(absentStudents);
            
            return students;
        }
    }
}
