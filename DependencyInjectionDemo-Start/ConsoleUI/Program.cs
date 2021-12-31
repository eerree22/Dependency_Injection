using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.GGYY();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();// => 我需要IApplication物件
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
