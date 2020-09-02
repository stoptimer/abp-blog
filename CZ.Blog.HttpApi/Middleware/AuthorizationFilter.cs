using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CZ.Blog.HttpApi.Middleware
{
    /// <summary>
    /// 权限过滤器
    /// </summary>
    public class AuthorizationFilter : IAuthorizationFilter
    {
        /// <summary>
        /// 权限方法
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            if (!(context.ActionDescriptor is ControllerActionDescriptor))
            {
                return;
            }
            var attributeList = new List<object>();
            attributeList.AddRange((context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(true));
            attributeList.AddRange((context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.DeclaringType.GetCustomAttributes(true));
            var authorizeAttributes = attributeList.OfType<CustomizeAuthorizeAttribute>().ToList();
            var claims = context.HttpContext.User.Claims;
            // 从claims取出用户相关信息，到数据库中取得用户具备的权限码，与当前Controller或Action标识的权限码做比较
            var userPermissions = "User_Edit";
            if (!authorizeAttributes.Any(s => s.Permission.Equals(userPermissions)))
            {
                context.Result = new JsonResult("没有权限");
            }
            return;

        }
    }
    /// <summary>
    /// 自定义权限属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomizeAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; }
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="permission"></param>
        public CustomizeAuthorizeAttribute(string permission)
        {
            Permission = permission;
        }

    }
}
