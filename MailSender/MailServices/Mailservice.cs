using ConfigServices;
using LogServices;
using System;

namespace MailServices
{
    public class Mailservice : IMailservice
    {
        private ILogProvider _logProvider;
        //private IConfigservice _configservice;
        private IConfigReader _configservice;

        public Mailservice(ILogProvider logProvider, IConfigReader configservice)
        {
            _logProvider = logProvider;
            _configservice = configservice;
        }

        //可以用"MsilKit"實作電子郵件發送功能
        public void Send(string title,string to , string body)
        {
            _logProvider.LogInfo("開始發EMAIL");

            string Server = _configservice.GetValue("SmtpServer");
            string UserName = _configservice.GetValue("UserName");
            string Password = _configservice.GetValue("Password");

            Console.WriteLine($" Config => Server:{Server}，UserName:{UserName}，Password:{Password}");

            Console.WriteLine($"發送郵件給{to}，標題:{title}，內容:{body}");

            _logProvider.LogInfo("EMAIL發送完成");

        }
    } 
}
