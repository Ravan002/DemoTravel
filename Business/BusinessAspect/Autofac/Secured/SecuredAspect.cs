﻿using Castle.DynamicProxy;
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
    public class SecuredAspect : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredAspect(string roles)
        {
            _roles=roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
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
