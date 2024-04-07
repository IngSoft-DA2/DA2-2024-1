
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación 1-n entre Owner y Pet
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.Pets)
                .WithOne(p => p.Owner);

            // Relación n-n entre Pet y Vet 
            modelBuilder.Entity<Pet>()
            .HasMany(p => p.Vets)
            .WithMany(v => v.Pets);

            // Relación n-n entre Pet y Vet a través de Appointment
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PetId, a.VetId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PetId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VetId);

            // For TPH
            // modelBuilder.Entity<Animal>()
            //     .HasDiscriminator<string>("AnimalType")
            //     .HasValue<Dog>("Dog")
            //     .HasValue<Cat>("Cat");

            // For TPT
            // modelBuilder.Entity<Animal>().ToTable("Animals");
            // modelBuilder.Entity<Cat>().ToTable("Cats");
            // modelBuilder.Entity<Dog>().ToTable("Dogs");   
            
            // For TPC
            // modelBuilder.Entity<Cat>().ToTable("Cats");
            // modelBuilder.Entity<Dog>().ToTable("Dogs");
        }

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

