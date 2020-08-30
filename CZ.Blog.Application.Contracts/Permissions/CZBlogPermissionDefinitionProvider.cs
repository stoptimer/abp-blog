using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;

namespace CZ.Blog.Application.Contracts.Permissions
{
    /// <summary>
    /// 权限提供
    /// </summary>
    public class CZBlogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        /// <summary>
        /// 定义
        /// </summary>
        /// <param name="context"></param>
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CZBlogPermissions.GroupName);
        }
    }
}
