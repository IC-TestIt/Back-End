using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Utils.Email
{
    public interface IEmailService
    {
        bool Send(Email email);
        void SendInvite(string emailAdress, string emailTitle, string description);
        void SendSignUp(string emailAdress, string emailTitle, int idStudent);
    }
}
