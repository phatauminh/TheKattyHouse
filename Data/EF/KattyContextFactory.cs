using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data.EF
{
    public class KattyContextFactory : IDesignTimeDbContextFactory<KattyDbContext>
    {
        public KattyDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TheKattyHouseDb");

            var optionsBuilder = new DbContextOptionsBuilder<KattyDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new KattyDbContext(optionsBuilder.Options);
        }
    }
}
