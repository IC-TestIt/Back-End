using TestIt.Data.Abstract;

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
            //return userRepository.Any(x => x.Email == email && x.Password == pswd);
            return true;
        }
    }
}
