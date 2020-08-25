using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;

namespace CZ.Blog.Application.Contracts.Permissions
{
    public class CZBlogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CZBlogPermissions.GroupName);
        }
    }
}
