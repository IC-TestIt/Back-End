using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class TeacherService : ITeacherService
    {
        private ITeacherRepository teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public IEnumerable<Teacher> Get() 
        {
            return teacherRepository.GetAll();
        }

        public Teacher GetSingle(int id)
        {
            return teacherRepository.GetSingle(id);
        }

        public Teacher GetByUser(int id) 
        {
            return teacherRepository.GetSingle(t => t.User.Id == id);
        }

        public void Save(Teacher t) 
        {
            teacherRepository.Add(t);
            teacherRepository.Commit();
        }

        public void Delete(int id)
        {
            Teacher t = teacherRepository.GetSingle(id);

            if(t != null) 
            {
                teacherRepository.DeleteWhere(x => x.Id == t.Id);
                teacherRepository.Commit();
            }
        }

        public void Update(int id, Teacher teacher)
        {
            Teacher t = teacherRepository.GetSingle(id);
            if (t != null && teacher.Id == t.Id)
            {
                teacherRepository.Update(teacher);
                teacherRepository.Commit();
            }
        }
        
    }
}