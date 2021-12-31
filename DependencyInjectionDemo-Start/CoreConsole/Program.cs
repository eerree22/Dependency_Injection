using System;
using Microsoft.Extensions.DependencyInjection;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var Services = new ServiceCollection(); //建立服務容器


                               //<ITestService, TestService_1> ITestService是用來被呼叫的服務介面，TestService_1是實作的服務
            Services.AddTransient<ITestService, TestService_1>(); //添加服務(Transient)
            //Services.AddTransient(typeof(ITestService),typeof(TestService_1));  //也可以這樣ADD


            //Services.AddScoped<ITestService, TestService_1>(); //添加服務(Scoped)

            //Services.AddSingleton<ITestService, TestService_1>(); //添加服務(Singleton)
            //Services.AddSingleton(typeof(ITestService), new TestService_1()); //Singleton也可以這樣ADD，適用服務建立需要傳入特定參數的類別

            /*  
             三種不同的生命週期
               Transient    : 每次請求都拿到一個新的物件
               Scoped       : 在Scope中請求都是同個物件
               Singleton    : 所有請求全部都是拿到同個物件
             */


            //Services.AddTransient<ITestService, TestService_2>();  只要切換實作的服務就可以改變行為

            using (var sp = Services.BuildServiceProvider())//服務定位器
            {
                var MyTestService = sp.GetService<ITestService>();  //用介面取得服務，找不到的話會return null
                //var MyTestService = sp.GetRequiredService<ITestService>();
                //GetService跟GetRequiredService差別在GetRequiredService找不到會報錯

                MyTestService.Name = "老張";
                MyTestService.SayHi();


                //使用Scope來控制服務的生命週期
                using (var MyScope = sp.CreateScope())
                {
                    var ScopeTestService = MyScope.ServiceProvider.GetService<ITestService>();
                    ScopeTestService.Name = "Sion";
                    ScopeTestService.SayHi();
                }
            }

            MyDITest(Services);

            Console.WriteLine("");
        }


        public static void MyDITest(ServiceCollection services)
        {
            services.AddScoped<MyController>();
            services.AddScoped<ILog, Log>();
            services.AddScoped<IConfig, Config>();
            services.AddScoped<ICloud, Cloud>();

            using (var sp = services.BuildServiceProvider())
            {
                //MyController所依賴的服務都會由DI的機制自己產生
                var c = sp.GetRequiredService<MyController>();
                c.Test();
            }
        }
    }
}
