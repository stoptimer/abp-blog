﻿using CZ.Blog.EntityFrameworkCore;
using CZ.Blog.HttpApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace CZ.Blog.API
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAutofacModule),
        typeof(CZBlogHttpApiModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(CZBlogFrameworkCoreModule)
        )]
    public class AppModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();
            Configure<AbpAuditingOptions>(options =>
            {
                options.IsEnabledForGetRequests = true;
                options.EntityHistorySelectors.AddAllEntities();
                options.ApplicationName = "BlogAPI";
            });
            context.Services.AddAuthentication("Bearer")//添加授权模式
            .AddIdentityServerAuthentication(Options =>
            {
                Options.Authority = configuration.GetSection("Ids4Config")["IssuerUri"];//授权服务器地址
                Options.RequireHttpsMetadata = false;//是否是https
                Options.ApiName = "blogapi";
            });

            context.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Version = "v1" });

                var xmlapipath = Path.Combine(AppContext.BaseDirectory, "CZ.Blog.HttpApi.xml");
                if (File.Exists(xmlapipath))
                {
                    options.IncludeXmlComments(xmlapipath, true);
                }
                var xmlapppath = Path.Combine(AppContext.BaseDirectory, "CZ.Blog.Application.Contracts.xml");
                if (File.Exists(xmlapipath))
                {
                    options.IncludeXmlComments(xmlapppath, true);
                }

            });
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
            app.UseAuditing();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseConfiguredEndpoints();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
                c.RoutePrefix = "";
            });
        }
    }
}
