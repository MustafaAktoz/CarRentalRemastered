using Core.Middlewares.Exception;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseMyExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseBuildAutofacRoot(this IApplicationBuilder app)
        {
            AutofacServiceTool.BuildAutofacRoot(app);
        }
    }
}
