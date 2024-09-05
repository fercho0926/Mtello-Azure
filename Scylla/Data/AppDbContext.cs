using Data.Entities;
using Data.Entities.Shared;
using Data.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Company> Company { get; set; }
        //public DbSet<PayCheckRecord> PayCheckRecords { get; set; }
        //public DbSet<BatchPaycheck> BatchPaycheck { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>()
            .HasOne(a => a.Company)
            .WithMany(c => c.Address)
            .HasForeignKey(a => a.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
            .HasOne(a => a.User)
            .WithMany(u => u.Address)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        }



    }
}
