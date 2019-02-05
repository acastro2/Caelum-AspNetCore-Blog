using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Blog.Infra
{
    public static class ConnectionFactory
    {
        public static System.Data.IDbConnection GetConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                    .AddEnvironmentVariables();
            var configuration = builder.Build();

            var connection = new SqlConnection(configuration.GetConnectionString("Blog"));
            connection.Open();

            return connection;
        }
    }
}
