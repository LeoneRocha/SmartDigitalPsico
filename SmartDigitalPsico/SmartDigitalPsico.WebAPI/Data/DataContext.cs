using SmartDigitalPsico.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartDigitalPsico.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
         
        public DbSet<User> Users { get; set; }
         


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Skill>().HasData(
            //    new Skill { Id = 1, Name = "Fireball", Damage = 30 },
            //    new Skill { Id = 2, Name = "Frenzy", Damage = 20 },
            //    new Skill { Id = 3, Name = "Dark Hole", Damage = 100 },
            //    new Skill { Id = 4, Name = "Blizzard", Damage = 50 }
            //);

            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("Admin");
        }
    }
}