
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ORT.Vet.Domain;

namespace ORT.Vet.DataAccess
{
    public class VetContext : DbContext
    {
        public VetContext() { }
        public VetContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Pet>? Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string directory = Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString(@"vetDB");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}

