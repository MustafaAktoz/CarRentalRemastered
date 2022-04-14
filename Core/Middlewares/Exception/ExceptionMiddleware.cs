using Core.Exceptions.Abstract;
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
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            string message = "Internal Server Error";

            if (e.GetType() == typeof(ValidationException)) return HandleFluentValidationException(httpContext, (ValidationException)e);
            if (typeof(ICustomException).IsAssignableFrom(e.GetType())) HandleCustomException(httpContext, out message, e);

            return httpContext.Response.WriteAsync(new StandardExceptionDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }

        private Task HandleFluentValidationException(HttpContext httpContext, ValidationException validationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

            return httpContext.Response.WriteAsync(new FluentValidationExceptionDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                FluentValidationErrors = validationException.Errors
            }.ToString());
        }

        private void HandleCustomException(HttpContext httpContext, out string message, System.Exception e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            message = e.Message;
        }
    }
}
