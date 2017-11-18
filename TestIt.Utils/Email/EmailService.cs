using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Linq;
using System.Collections.Generic;

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

        public void Send(Email email, IEnumerable<string> emails = null)
        {
            try
            {
                var mimeMessage = BuildMimeMessage(email.Subject, email.BodyContent, "", emails);

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.SslOnConnect);
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
        
        private MimeMessage BuildMimeMessage(string subject, string body, string toAddress, IEnumerable<string> toEmails = null)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, _fromAdress));
            
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("plain")
            {
                Text = body
            };

            if (toEmails != null)
            {
                mimeMessage.To.AddRange(toEmails.Select(x => new MailboxAddress(x)).ToList());
                return mimeMessage;
            }

            mimeMessage.To.Add(new MailboxAddress(toAddress, toAddress));

            return mimeMessage;
        }
    }
}
