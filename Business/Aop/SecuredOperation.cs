using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Aop
{
    public class SecuredOperation : MethodInterception
    {
        private readonly HashSet<string> _rolePermissions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(params string[] rolePermissions)
        {
            _rolePermissions = rolePermissions.ToHashSet();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRolePermissions();

            if (roleClaims != null && _rolePermissions.Any(r => roleClaims.Contains(r)))
                return;

            throw new Exception($"{Messages.AuthorizationDenied}, Adres->{invocation.Method.DeclaringType.Name}::{invocation.Method.Name}");
        }
    }
}
