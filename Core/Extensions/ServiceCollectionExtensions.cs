using Core.DependencyResolvers.Abstract;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyResolvers(this IServiceCollection services, params ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            ServiceTool.Create(services);
        }
    }
}
