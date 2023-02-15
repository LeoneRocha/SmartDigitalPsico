
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Model.Entity;

namespace SmartDigitalPsico.Data.Context
{
    public class SmartDigitalPsicoDataContext : DbContext
    {
        public SmartDigitalPsicoDataContext(DbContextOptions<SmartDigitalPsicoDataContext> options) : base(options)
        {

        }
     
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("SmartDigitalPsico.Data"));
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<User> Users { get; set; }

        public DbSet<RoleGroup> RoleGroups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role).HasDefaultValue("Admin"); 
             
        }

    }
}