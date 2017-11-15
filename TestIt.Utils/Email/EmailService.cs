using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace TestIt.Utils.Email
{
    public class EmailService : IEmailService
    {
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPortNumber = 465;
        private readonly string _fromAdress = ""; //Set username from email adress
        private const string FromAdressTitle = "TestIt";
        private readonly string _password; //Set password from email adress

        public EmailService(IConfiguration configuration)
        {
            _fromAdress = configuration.GetSection("EmailOptions").GetSection("FromAdress").Value;
            _password = configuration.GetSection("EmailOptions").GetSection("Password").Value;
        }

        public void Send(Email email)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, _fromAdress));
                mimeMessage.To.Add(new MailboxAddress(email.ToAdressTitle, email.ToAdress));
                mimeMessage.Subject = email.Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = email.BodyContent

                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.SslOnConnect);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2"); // Must be removed for Gmail SMTP
                    client.Authenticate(_fromAdress, _password);
                    client.Send(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    client.Disconnect(true);

                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
