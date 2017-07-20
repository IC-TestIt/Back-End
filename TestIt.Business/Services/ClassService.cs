using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ClassService : IClassService
    {
        private IClassRepository classRepository;
        private IUserRepository userRepository;

        public ClassService (IClassRepository classRepository, IUserRepository userRepository)
        {
            this.classRepository = classRepository;
            this.userRepository = userRepository;
        }
        public void Save(Class c)
        {
            classRepository.Add(c);
            classRepository.Commit();
        }

        public IEnumerable<User> ClassUsers (int id)
        {
            return userRepository.ClassUsers(id);
        }
    }
}
