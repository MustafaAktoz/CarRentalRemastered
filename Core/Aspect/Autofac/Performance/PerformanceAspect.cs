using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspect.Autofac.Performance
{
    public class PerformanceAspect:MethodInterception
    {
        double _interval;
        Stopwatch _stopwatch;
        public PerformanceAspect(double interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
                Debug.WriteLine($"Performans Uyarısı: '{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}' methodu çalışırken, belirtilen '{_interval}' saniyelik süreyi aştı: '{_stopwatch.Elapsed.TotalSeconds}' saniye sürdü.");

            _stopwatch.Reset();
        }
    }
}
