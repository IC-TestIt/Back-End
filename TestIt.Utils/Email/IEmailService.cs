using System.Collections.Generic;

namespace TestIt.Utils.Email
{
    public interface IEmailService
    {
        void Send(Email email, IEnumerable<string> emails = null);
    }
}
