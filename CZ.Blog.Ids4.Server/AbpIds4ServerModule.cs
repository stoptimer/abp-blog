using CZ.Blog.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using System.Linq;

namespace CZ.Blog.Ids4.Server
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(CZBlogFrameworkCoreModule)
        )]
    public class AbpIds4ServerModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.EntityHistorySelectors.AddAllEntities();
                options.ApplicationName = "IdentityService";
            });
            context.Services.AddIdentityServer()
                       .AddDeveloperSigningCredential()
                        .AddInMemoryApiScopes(Config.ApiScopes)
                        .AddInMemoryClients(Config.Clients);



        }

        public override void OnApplicationInitialization(
            ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuditing();
            app.UseConfiguredEndpoints();

        }

    }
}
