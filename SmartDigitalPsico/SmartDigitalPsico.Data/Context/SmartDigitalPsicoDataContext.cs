
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Globalization;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SmartDigitalPsico.Repository.Context
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

        public DbSet<PatientAdditionalInformation> PatientAdditionalInformations { get; set; }

        public DbSet<PatientHospitalizationInformation> PatientHospitalizationInformations { get; set; }

        public DbSet<PatientMedicationInformation> PatientMedicationInformations { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }

        public DbSet<PatientNotificationMessage> PatientNotificationMessages { get; set; }

        public DbSet<ApplicationLanguage> ApplicationLanguages { get; set; }

        public DbSet<ApplicationConfigSetting> ApplicationConfigSettings { get; set; }

        #endregion Principais

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string valorbr = new CultureInfo("pt-BR").Name;

            modelBuilder.Entity<Patient>().Property(b => b.Profession).IsRequired(false);//optinal case

            #region MOCK

            modelBuilder.Entity<Gender>().HasData(
               new Gender { Id = 1, Description = "Masculino", Language = valorbr },
               new Gender { Id = 2, Description = "Feminino", Language = valorbr }
               );

            modelBuilder.Entity<Office>().HasData(
               new Office { Id = 1, Description = "Psicólogo", Language = valorbr },
               new Office { Id = 2, Description = "Psicóloga", Language = valorbr },
               new Office { Id = 3, Description = "Clínico", Language = valorbr }
               );

            modelBuilder.Entity<Specialty>().HasData(
              new Specialty { Id = 1, Description = "Psicologia Clínica", Language = valorbr },
              new Specialty { Id = 2, Description = "Psicologia Social", Language = valorbr },
              new Specialty { Id = 3, Description = "Psicologia educacional", Language = valorbr },
              new Specialty { Id = 4, Description = "Psicologia Esportiva ", Language = valorbr },
              new Specialty { Id = 5, Description = "Psicologia organizacional", Language = valorbr },
              new Specialty { Id = 6, Description = "Psicologia hospitalar", Language = valorbr },
              new Specialty { Id = 7, Description = "Psicologia do trânsito", Language = valorbr }
              );
            #endregion

            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("Admin");
            bool valorPadraoEnable = true;
            #region Domains  DEFAULTs VALUEs
            modelBuilder.Entity<Gender>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<Specialty>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<Office>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<RoleGroup>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);

            #endregion Domains  DEFAULTs VALUEs

            #region Principals  DEFAULTs VALUEs

            modelBuilder.Entity<User>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<Medical>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<Patient>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);

            modelBuilder.Entity<PatientAdditionalInformation>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<PatientHospitalizationInformation>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<PatientMedicationInformation>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<PatientNotificationMessage>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
            modelBuilder.Entity<PatientRecord>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);

            #endregion Principals  DEFAULTs VALUEs

            base.OnModelCreating(modelBuilder);
        }
    }
}