using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;
using Core.Exceptions.Concrete;

namespace Business.BusinessAspect.Autofac.Security
{
    public class SecuredOperationAspect : MethodInterception
    {
        string[] _roles;
        IHttpContextAccessor _httpContextAccessor;
        public SecuredOperationAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roles = _httpContextAccessor.HttpContext.User.GetClaimRoles();
            foreach (var role in roles)
            {
                if (_roles.Contains(role)) return;
            }

            throw new AuthorizationCustomException(Messages.NotAuthorized);
        }
    }
}
