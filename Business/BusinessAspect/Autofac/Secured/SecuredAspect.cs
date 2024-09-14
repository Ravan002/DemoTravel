using Castle.DynamicProxy;
using Core.Extensions;
using Core.Helpers.Interceptors;
using Core.Helpers.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspect.Autofac.Secured
{
    public class SecuredAspect(string roles) : MethodInterception
    {
        private readonly string[] _roles = roles.Split(',');
        private readonly IHttpContextAccessor _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>()!;

        protected override void OnBefore(IInvocation invocation)
        {

            var user = _httpContextAccessor?.HttpContext?.User;
            var roleClaims= _httpContextAccessor?.HttpContext?.User.ClaimRoles();
            foreach (var roleClaim in _roles)
            {
                if (roleClaims!.Contains(roleClaim))
                {
                    return;
                }
            }
            throw new Exception("icaze yoxdu");
        }
    }
}
