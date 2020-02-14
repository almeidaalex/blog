using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Blog.Infra
{
    public static class ConnectionFactory
    {
        public static SqlConnection CriaConexaoAberta()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();

            var conexao = new SqlConnection(configuration.GetConnectionString("Blog"));
            conexao.Open();
            return conexao;
        }
    }
}
