using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public class AutofacServiceTool
    {
        public static ILifetimeScope AutofacRoot { get; private set; }

        public static void BuildAutofacRoot(IApplicationBuilder app)
        {
            AutofacRoot = app.ApplicationServices.GetAutofacRoot();
        }

        public static T GetService<T>()
        {
            return AutofacRoot.Resolve<T>();
        }
    }
}
