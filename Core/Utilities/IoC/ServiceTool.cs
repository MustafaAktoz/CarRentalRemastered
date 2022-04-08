using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
