using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace testing.Services
{
    public class PasswordEmailSender : IEmailSender
    {
        public IConfiguration configuration  { get; set; }
        public PasswordEmailSender(IConfiguration conf)
        {
            configuration = conf;
        }
        private bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        public void SendMail(string recipientMail,string recipientName, string password)
        {
            var sectionSMTP = configuration.GetSection("SMTP");
            var host = sectionSMTP.GetValue<string>("host","");
            var port = sectionSMTP.GetValue<int>("port",0);
            var sender = sectionSMTP.GetValue<string>("ClinicEmail","");
            var pass = sectionSMTP.GetValue<string>("ClinicEmailPassword","");
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback += ValidateRemoteCertificate;
                client.Connect(host,port);
                client.Authenticate(sender,pass);

                string text = System.IO.File.ReadAllText(@"assets/mail/index.html");
                text = text.Replace("PLACEHOLDERFORPASS", password);
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = text
                };
                var message = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };
                message.From.Add(new MailboxAddress("PopMedical Clinic", sender));
                message.To.Add(new MailboxAddress(recipientName, recipientMail));
                message.Subject = "Регистрация в клинике PopMedical";
                client.Send(message);
                client.Disconnect(true);

            }
        }
    }
}
