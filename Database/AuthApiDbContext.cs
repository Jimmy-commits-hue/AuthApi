using AuthApiBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApiBackend.Database
{
    public class AuthApiDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<ContactDetails> ContactDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();

            modelBuilder.Entity<User>().HasOne(u => u.ContactDetails).WithOne(u => u.User).HasForeignKey<ContactDetails>(u => u.UserId).
                OnDelete(DeleteBehavior.Cascade);
    ;

            base.OnModelCreating(modelBuilder);
        }

        public AuthApiDbContext(DbContextOptions<AuthApiDbContext> options) : base(options) { }
    }
}
