using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using System.Linq;

namespace TestIt.Data.Repositories
{
    public class StudentRepository : EntityBaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(TestItContext context)
            : base(context)
        {

        }

        public IEnumerable<StudentTestDTO> GetTests(int id)
        {
            var unavailableClassTests = (from a in _context.Exams
                                         where a.StudentId == id
                                         select a.ClassTestsId);

            var tests = (from a in _context.Classes
                         join b in _context.ClassStudents on a.Id equals b.ClassId
                         join c in _context.ClassTests on b.ClassId equals c.ClassId
                         join d in _context.Tests on c.TestId equals d.Id
                         join e in _context.Teachers on a.TeacherId equals e.Id
                         join f in _context.Users on e.UserId equals f.Id
                         where b.StudentId == id && !unavailableClassTests.Contains(c.Id)
                         select new StudentTestDTO()
                         {
                             ClassName = a.Description,
                             ClassTestId = c.Id,
                             EndDate = c.EndDate,
                             Name = d.Description,
                             TeacherName = f.Name
                         }).ToList();
            
            return tests;
        }
    }
}