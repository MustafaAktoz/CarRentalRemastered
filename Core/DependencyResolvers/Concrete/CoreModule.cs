using Core.CrossCuttingConcerns.Cashing.Abstract;
using Core.CrossCuttingConcerns.Cashing.Concrete;
using Core.DependencyResolvers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers.Concrete
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
