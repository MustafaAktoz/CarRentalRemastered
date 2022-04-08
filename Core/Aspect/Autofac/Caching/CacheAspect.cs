using Core.CrossCuttingConcerns.Cashing.Abstract;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        double _duration;
        ICacheService _cacheService;

        public CacheAspect(double duration = 60)
        {
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";
            var arguments = invocation.Arguments;
            var key = $"{methodName}({string.Join(',', arguments.Select(a => a?.ToString() ?? "<Null>"))})";

            if (_cacheService.IsAdd(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
            }

            invocation.Proceed();
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
