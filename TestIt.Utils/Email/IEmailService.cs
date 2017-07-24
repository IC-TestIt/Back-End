using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Model.Entities;

namespace TestIt.Utils.Email
{
    public interface IEmailService
    {
        bool Send(Email email);
        void SendInvite(User user, Class room);
        void SendSignUp(User user);
    }
}
