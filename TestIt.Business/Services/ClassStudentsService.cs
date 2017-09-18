using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Data.Repositories;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ClassStudentsService : IClassStudentsService
    {
        private IClassStudentsRepository classStudentsRepository;

        public ClassStudentsService(IClassStudentsRepository classStudentsRepository)
        {
            this.classStudentsRepository = classStudentsRepository;
        }

        public void Save(ClassStudents cs)
        {
            classStudentsRepository.Add(cs);
            classStudentsRepository.Commit();
        }

        public void DeleteStudent(int id, int studentId)
        {
            classStudentsRepository.DeleteWhere(x => x.ClassId == id && x.StudentId == studentId);
            classStudentsRepository.Commit();
        }

        public void Delete(int id)
        {
            classStudentsRepository.DeleteWhere(x => x.ClassId == id);
            classStudentsRepository.Commit();
        }
    }
}
