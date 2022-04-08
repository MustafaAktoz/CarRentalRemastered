using Core.CrossCuttingConcerns.Cashing.Abstract;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspect.Autofac.Caching
{
    public class RemoveCashAspect:MethodInterception
    {
        string _pattern;
        ICacheService _cacheService;

        public RemoveCashAspect(string pattern)
        {
            _pattern = pattern;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(_pattern);
        }
    }
}
