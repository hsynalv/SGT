using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SGT.Persistence.Context;

namespace SGT.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SGT_APIDbContext>
    {
        public SGT_APIDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SGT_APIDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new SGT_APIDbContext(builder.Options);
        }
    }
}
