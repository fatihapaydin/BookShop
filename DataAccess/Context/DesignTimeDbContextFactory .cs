using System;
using System.IO;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SampleContext>
    {

        public SampleContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var array = Directory.GetCurrentDirectory().Split("DataAccess");
            var rootDirectory = array[0] + "Api";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(rootDirectory)
                        .AddJsonFile("appsettings." + env.MakeVariableFirsLetterToUpperCase() + ".json").Build();

            var builder = new DbContextOptionsBuilder<SampleContext>();

            builder.UseNpgsql(configuration.GetSection("Config:SqlConnectionString").Value);

            return new SampleContext(builder.Options);
        }
    }
}