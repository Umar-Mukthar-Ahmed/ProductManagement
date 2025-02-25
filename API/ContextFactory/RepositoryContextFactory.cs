using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Repository;
using System.IO;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        // Build configuration to access appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Set up DbContext options
        var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();

        // Use SQL Server connection string from appsettings.json
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProductDbConnection"),b => b.MigrationsAssembly("API")) ;

        // Return the configured DbContext
        return new RepositoryContext(optionsBuilder.Options);
    }
}
