using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        public DbSet<Models.Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                   .AddEnvironmentVariables();
            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Blog"));
        }
    }
}
