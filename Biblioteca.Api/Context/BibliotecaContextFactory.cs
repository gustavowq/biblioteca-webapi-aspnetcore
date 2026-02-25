using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Biblioteca.Api.Context
{
    public class BibliotecaContextFactory : IDesignTimeDbContextFactory<BibliotecaContext>
    {
        public BibliotecaContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddJsonFile(Path.Combine("Biblioteca.Api", "appsettings.json"), optional: true)
                .AddJsonFile(Path.Combine("Biblioteca.Api", $"appsettings.{env}.json"), optional: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("ConexaoPadrao")
                ?? configuration["ConnectionStrings:ConexaoPadrao"];

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'ConexaoPadrao' not found.");

            var optionsBuilder = new DbContextOptionsBuilder<BibliotecaContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BibliotecaContext(optionsBuilder.Options);
        }
    }
}
