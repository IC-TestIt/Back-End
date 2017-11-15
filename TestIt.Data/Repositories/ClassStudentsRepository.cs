using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using System.Linq;

namespace TestIt.Data.Repositories
{
    public class ClassStudentsRepository : EntityBaseRepository<ClassStudents>, IClassStudentsRepository
    {
        public ClassStudentsRepository(TestItContext context)
            : base(context)
        { }

        public IEnumerable<StudentClassDTO> GetClasses(int id)
        {
            var classes = (from a in Context.ClassStudents
                           join b in Context.Classes on a.ClassId equals b.Id
                           join c in Context.Teachers on b.TeacherId equals c.Id
                           join d in Context.Users on c.UserId equals d.Id
                           where a.StudentId == id
                           select new StudentClassDTO
                           {
                               ClassId = b.Id,
                               Description = b.Description,
                               TeacherName = d.Name
                           }).ToList();

            foreach(StudentClassDTO s in classes)
            {
                s.CorrectedStudentTests = (from a in Context.Exams
                                           join b in Context.ClassTests on a.ClassTestsId equals b.Id
                                           join c in Context.Tests on b.TestId equals c.Id
                                           where b.ClassId == s.ClassId && a.StudentId == id && a.Status == 3
                                           select new CorrectedStudentTestsDTO
                                           {
                                               TestId = c.Id,
                                               BeginDate = b.BeginDate,
                                               EndDate = b.EndDate,
                                               ClassTestId = a.ClassTestsId,
                                               Description = c.Description,
                                               ExamId = a.Id,
                                               Grade = a.TotalGrade
                                           }).ToList();
            }

            return classes;
        }
    }
}
