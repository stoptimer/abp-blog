using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CZ.Blog.EntityFrameworkCore.DbMigrations
{
    public class CZBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<CZBlogMigrationsDbContext>
    {
        public CZBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CZBlogMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("MySql"));

            return new CZBlogMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CZ.Blog.API/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
