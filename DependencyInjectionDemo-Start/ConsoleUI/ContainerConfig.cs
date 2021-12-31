using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using System.Reflection;

namespace ConsoleUI
{
    public static class ContainerConfig
    {
        public static IContainer GGYY()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>(); //當有需要IBusinessLogic時給予BusinessLogic的實體物件

            /*
             註冊DemoLibrary的Utilities資料夾下所有class到它所屬的interface
             跟上面BusinessLogic做的事情相同
             */
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();//建立放class的容器
        }

    }
}
