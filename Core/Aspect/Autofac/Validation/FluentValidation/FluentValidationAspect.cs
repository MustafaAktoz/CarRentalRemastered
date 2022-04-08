using Castle.DynamicProxy;
using Core.Constants;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation.FluentValidation
{
    public class FluentValidationAspect:MethodInterception
    {
        Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            if(!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.TheTypeSubmittedIsNotAnIValidator);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator=(IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(a=>a.GetType()==entityType);
            foreach(var entity in entities)
            {
                FluentValidationTool.Validate(validator,entity);
            }
        }
    }
}
