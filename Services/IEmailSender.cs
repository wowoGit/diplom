using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testing.Services
{
    public interface IEmailSender
    {
        void SendMail(string recipientEmail,string recipientName, string body);
    }
}
