using LogServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LogExtensions
    {
        public static void AddLogService(this IServiceCollection services)
        {
            services.AddScoped<ILogProvider, LogProvider>();
        }

    }
}
