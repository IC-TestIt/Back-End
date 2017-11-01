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
                           where a.TeacherId == id
                           select new TeacherClassDTO()
                           {
                               Description = a.Description,
                               Id = a.Id,
                               Average = c.TotalGrade,
                           }).ToList();

            var list = (from a in classes
                        group a by a.Id into g
                        select new TeacherClassDTO()
                        {
                            Id = g.FirstOrDefault().Id,
                            Description = g.FirstOrDefault().Description,
                            Average = g.Average(x => x.Average),
                            Size = -1
                           
                        }).ToList().Distinct();

            foreach (TeacherClassDTO l in list)
            {
                var Size =(from a in Context.Classes
                           join b in Context.ClassStudents on )
            }

            return classes;
        }
    }
}