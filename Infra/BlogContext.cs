using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Infra
{
    public class BlogContext : DbContext 
    {
        public DbSet<Post> Posts { get; set; }


        //2.2
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();
            IConfiguration configuration = builder.Build();

            var conexao = configuration.GetConnectionString("Blog");

            optionsBuilder.UseSqlServer(conexao);
            optionsBuilder.UseLoggerFactory(MyLoggerFactory); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
