using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Middlewares.Exception.ExceptionDetailObjects
{
    public class FluentValidationExceptionDetails
    {
        public int StatusCode { get; set; }
        public IEnumerable<ValidationFailure> FluentValidationErrors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
