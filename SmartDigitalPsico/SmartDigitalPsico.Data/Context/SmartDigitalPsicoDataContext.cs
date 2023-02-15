
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Globalization;

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

        #region Statics 

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        #endregion

        #region Principais

        public DbSet<User> Users { get; set; }

        public DbSet<Medical> Medicals { get; set; }

        public DbSet<Patient> Patients { get; set; }
        #endregion Principais

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            string valorbr = new CultureInfo("pt-BR").Name;

            /*modelBuilder.Entity<Gender>().HasData(
               new Gender {  Description = "Masculino", Language = valorbr },
               new Gender {  Description = "Feminino", Language = valorbr } 
           );*/
            modelBuilder.Entity<User>()
                .Property(u => u.Role).HasDefaultValue("Admin");

        }

    }
}