using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;


namespace MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            //services.AddScoped<IConfigservice, EnvVarConfigservice>();

            //***服務實作需要先設定時的寫法***
            //services.AddScoped(typeof(IConfigservice), x => new TextFileConfigService { FilePath = "MyMailConfig.txt" });

            services.AddConfigService("MyMailConfig.txt");//改用擴充方法來新增服務

            //services.AddScoped<ILogProvider, LogProvider>();
            services.AddLogService();//改用擴充方法來新增服務

            services.AddScoped<IMailservice, Mailservice>();

            using (var Provider = services.BuildServiceProvider())
            {
                var ms = Provider.GetRequiredService<IMailservice>();

                ms.Send("安安", "老王", "最近好嗎?");
            }


            Console.WriteLine("Hello World!");
        }
    }
}
