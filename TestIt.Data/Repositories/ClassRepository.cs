using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.DTO;
using TestIt.Model.Entities;
using System.Linq;

namespace TestIt.Data.Repositories
{
    public class ClassRepository : EntityBaseRepository<Class>, IClassRepository
    {
        public ClassRepository(TestItContext context)
            : base(context)
        { }

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

            var list = (from a in classes
                        group a by a.Id into g
                        select new TeacherClassDTO()
                        {
                            Id = g.FirstOrDefault().Id,
                            Description = g.FirstOrDefault().Description,
                            Average = g.Average(x => x.TotalGrade),
                            Size = g.GroupBy(x => x.StudentId).Count()
                           
                        }).OrderByDescending(x => x.Average).ToList();


            return list;
        }
    }
}