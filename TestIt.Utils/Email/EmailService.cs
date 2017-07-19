using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt.Utils.Email
{
    public class EmailService : IEmailService
    {
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPortNumber = 465;
        private string FromAdress = ""; //Set username from email adress
        private const string FromAdressTitle = "TestIt";
        private string Password = ""; //Set password from email adress

        public EmailService(IConfiguration configuration)
        {
            this.FromAdress = configuration.GetSection("EmailOptions").GetSection("FromAdress").Value;
            this.Password = configuration.GetSection("EmailOptions").GetSection("Password").Value;
        }

        public bool Send(Email email)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAdress));
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
                    client.Authenticate(FromAdress, Password);
                    client.Send(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    client.Disconnect(true);

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
