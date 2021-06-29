namespace EFCoreDemo.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    /// <summary>
    /// Why do we need this?
    /// EF Core Add-Migrations command is a "design-time" action, and EF Core doesn't know 
    /// how to use our "runtime" Startup.cs code to create an instance of LocalDbContext
    /// </summary>
    public class LocalDesignTimeDbContextFactory : IDesignTimeDbContextFactory<LocalDbContext>
    {
        public LocalDbContext CreateDbContext(string[] args)
        {
            // Struggling to come up with an elegant way to get the connection string here. 
            // The instance of this created to run migrations is not resolved by the IServiceCollection
            // and uses a parameterless constructor. Ideally you want to use the IOptions pattern and follow IDesign.

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetValue<string>("Settings:LocalConnectionString");

            // string environment = configuration.GetValue<string>("Environment");
            // string decryptedConnectionString = Cryptographer.Decrypt(environment, connectionString);

            // In IDesign, the commented code above would work if your Cryptographer class was in your Accessors project,
            // or a static class in a Common/Utilities project. 

            // It also crossed my mind that it might possible to leave the connection strings unencrypted with
            // integrated security as true, and setup your release to sign in as a user with refined permissions.

            return new LocalDbContext(
                GetDBContextOptions(connectionString));
        }

        public static DbContextOptions GetDBContextOptions(string connectionString)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder
                .UseSqlServer(
                    connectionString,
                    db => db.MigrationsHistoryTable("Migrations", LocalDbContext.DefaultSchema));
            return dbContextOptionsBuilder.Options;
        }
    }
}
