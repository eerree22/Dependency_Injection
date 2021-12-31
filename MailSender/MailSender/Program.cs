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
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IConfigservice, EnvVarConfigservice>();
            services.AddScoped<ILogProvider, LogProvider>();
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
