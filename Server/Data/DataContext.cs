using BicycleRental.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BicycleRental.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>().ToTable("Bikes");
            modelBuilder.Entity<BikesType>().ToTable("BikesTypes");
            modelBuilder.Entity<Rental>().ToTable("Rentals");
            modelBuilder.Entity<User>().ToTable("Users").HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Role>().ToTable("Roles");
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<BikesType> BikesType { get; set;}
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
