using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace INTUS.SalesManager.Infrastructure.DataAccess;

public class DbContextFactory : IDesignTimeDbContextFactory<SalesManagerDbContext>
{
    public SalesManagerDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.migration.json")
            .AddJsonFile("appsettings.migration.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<SalesManagerDbContext>();
        dbContextOptionsBuilder.UseSqlServer(
            connectionString,
            builder => builder.MigrationsAssembly(typeof(SalesManagerDbContext).GetTypeInfo().Assembly.GetName().Name));
        return new SalesManagerDbContext(dbContextOptionsBuilder.Options);
    }
}
