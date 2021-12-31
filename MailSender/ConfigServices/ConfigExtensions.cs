using System;
using System.Collections.Generic;
using System.Text;
using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigExtensions
    {
        public static void AddConfigService(this IServiceCollection services, string Path)
        {
            services.AddScoped(typeof(IConfigservice), x => new TextFileConfigService { FilePath = Path });
        }


    }
}
