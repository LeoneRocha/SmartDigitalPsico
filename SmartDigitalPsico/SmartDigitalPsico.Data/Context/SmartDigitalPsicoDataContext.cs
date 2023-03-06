
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context.Helper;
using System.Globalization;
using System.Reflection.Metadata;

namespace SmartDigitalPsico.Repository.Context
{
    public class SmartDigitalPsicoDataContext : EntityDataContext
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
        //#region Statics 
        //public DbSet<Gender> Genders { get; set; }
        //public DbSet<Office> Offices { get; set; }
        //public DbSet<RoleGroup> RoleGroups { get; set; }
        //public DbSet<Specialty> Specialties { get; set; }
        //public DbSet<ApplicationLanguage> ApplicationLanguages { get; set; }
        //public DbSet<ApplicationConfigSetting> ApplicationConfigSettings { get; set; }
        //#endregion

        //#region Principais

        //public DbSet<Medical> Medicals { get; set; }

        //public DbSet<Patient> Patients { get; set; }

        //public DbSet<PatientAdditionalInformation> PatientAdditionalInformations { get; set; }

        //public DbSet<PatientHospitalizationInformation> PatientHospitalizationInformations { get; set; }

        //public DbSet<PatientMedicationInformation> PatientMedicationInformations { get; set; }
        //public DbSet<PatientRecord> PatientRecords { get; set; }

        //public DbSet<PatientNotificationMessage> PatientNotificationMessages { get; set; }

        //public DbSet<PatientFile> PatientFiles { get; set; }

        //public DbSet<MedicalFile> MedicalFiles { get; set; }

        //#endregion Principais

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureProprietiesEntity.Configure(modelBuilder);

            DataMockHelper.GenerateMock(modelBuilder);

            ConfigureRelationsHelper.Configure(modelBuilder);

            ConfigureDefaultValuesHelper.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        } 
    }
}