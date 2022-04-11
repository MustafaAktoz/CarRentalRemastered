using Core.Middlewares.Exception.ExceptionDetailObjects;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middlewares.Exception
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception e)
            {
                await HandleException(httpContext, e);
            }
        }

        private Task HandleException(HttpContext httpContext, System.Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 500;
            string message = "Internal Server Error";

            if (e.GetType() == typeof(ValidationException)) return FluentValidationHandleException(httpContext, (ValidationException)e);

            return httpContext.Response.WriteAsync(new StandardExceptionDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }

        private Task FluentValidationHandleException(HttpContext httpContext, ValidationException validationException)
        {
            httpContext.Response.StatusCode = 400;

            return httpContext.Response.WriteAsync(new FluentValidationExceptionDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                FluentValidationErrors = validationException.Errors
            }.ToString()) ;
        }
    }
}
