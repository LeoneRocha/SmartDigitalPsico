
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity;

namespace SmartDigitalPsico.Data.Context
{
    public class SmartDigitalPsicoDataContext : DbContext
    {
        public SmartDigitalPsicoDataContext(DbContextOptions<SmartDigitalPsicoDataContext> options) : base(options)
        {

        }

        public DbSet<User> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("Admin");
        }

    }
}