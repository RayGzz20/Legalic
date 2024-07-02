using LawyerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LawyerApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lawyer>()
                .HasIndex(l => l.LicenseNumber)
                .IsUnique();

            modelBuilder.Entity<Lawyer>()
                .HasIndex(l => l.Email)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}