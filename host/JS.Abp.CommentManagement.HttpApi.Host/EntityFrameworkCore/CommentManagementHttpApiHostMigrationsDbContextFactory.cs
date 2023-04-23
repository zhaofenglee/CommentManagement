using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace JS.Abp.CommentManagement.EntityFrameworkCore;

public class CommentManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CommentManagementHttpApiHostMigrationsDbContext>
{
    public CommentManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CommentManagementHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("CommentManagement"));

        return new CommentManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
