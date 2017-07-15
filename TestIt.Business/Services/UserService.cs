﻿using System.Collections.Generic;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        public UserService (IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool ValidLogin(string email, string pswd)
        {
            return userRepository.Any(x => x.Email == email && x.Password == pswd);
        }

        public IEnumerable<User> Get() 
        {
            return userRepository.GetAll();
        }

        public User GetSingle(int id)
        {
            return userRepository.GetSingle(id);
        }

        public void Save(User t) 
        {
            userRepository.Add(t);
            userRepository.Commit();
        }

        public void Delete(int id)
        {
            User t = userRepository.GetSingle(id);

            if(t != null) 
            {
                userRepository.DeleteWhere(x => x.Id == t.Id);
                userRepository.Commit();
            }
        }

        public void Update(int id, User user)
        {
            User t = userRepository.GetSingle(id);
            if (t != null && user.Id == t.Id)
            {
                userRepository.Update(user);
                userRepository.Commit();
            }
        }
    }
}
