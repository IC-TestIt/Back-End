using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Utils.Email
{
    public interface IEmailService
    {
        bool Send(Email email);
    }
}
