using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals; 

namespace SmartDigitalPsico.Repository.Context
{
    public class EntityDataContext : DbContext

    {
        public EntityDataContext(DbContextOptions<SmartDigitalPsicoDataContext> options) : base(options)
        {

        }

        #region Statics 
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<ApplicationLanguage> ApplicationLanguages { get; set; }
        public DbSet<ApplicationConfigSetting> ApplicationConfigSettings { get; set; }

        public DbSet<ApplicationCacheLog> ApplicationCacheLogs { get; set; }
        #endregion

        #region Principais

        public DbSet<Medical> Medicals { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientAdditionalInformation> PatientAdditionalInformations { get; set; }

        public DbSet<PatientHospitalizationInformation> PatientHospitalizationInformations { get; set; }

        public DbSet<PatientMedicationInformation> PatientMedicationInformations { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }

        public DbSet<PatientNotificationMessage> PatientNotificationMessages { get; set; }

        public DbSet<PatientFile> PatientFiles { get; set; }

        public DbSet<MedicalFile> MedicalFiles { get; set; }

        #endregion Principais

    }
}
