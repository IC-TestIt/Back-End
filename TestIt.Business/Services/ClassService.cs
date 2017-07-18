using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ClassService : IClassService
    {
        private IClassRepository classRepository;

        public ClassService (IClassRepository classRepository)
        {
            this.classRepository = classRepository;
            
        }
        public void Save(Class c)
        {
            classRepository.Add(c);
            classRepository.Commit();
        }

        

    }
}
