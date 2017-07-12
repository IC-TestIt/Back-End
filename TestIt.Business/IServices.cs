using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Business
{
    public interface IUserService
    {
        bool ValidLogin(string email, string pswd);
    }
}
