
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using System.Globalization;
using System.Reflection.Metadata;

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
        public DbSet<ApplicationLanguage> ApplicationLanguages { get; set; }
        public DbSet<ApplicationConfigSetting> ApplicationConfigSettings { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            configureProprieties(modelBuilder);

            generateMock(modelBuilder);

            configureRelations(modelBuilder);

            configureDefaultValues(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void configureProprieties(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(b => b.Profession).IsRequired(false);//optinal case
        }

        private void configureDefaultValues(ModelBuilder modelBuilder)
        {
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
        }

        private void configureRelations(ModelBuilder modelBuilder)
        {
            //https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/relationships

            #region Medical
            // configures one-to-many relationship
            modelBuilder.Entity<Medical>()
                     .HasOne(p => p.Office)
                     .WithMany(b => b.Medicals)
                     .HasForeignKey("OfficeId")
                     .IsRequired();

            // configures one-to-many relationship
            //modelBuilder.Entity<Medical>().HasOne(p => p.CreatedUser).WithOne();

            //modelBuilder.Entity<Medical>().Navigation(b => b.CreatedUser).UsePropertyAccessMode(PropertyAccessMode.Property);

            // configures one-to-many relationship
            modelBuilder.Entity<Medical>()
                  .HasOne(p => p.User)
                  .WithMany(b => b.MedicalsUsers)
                  .HasForeignKey(t => t.UserId)
                  .OnDelete(DeleteBehavior.NoAction)
                  .IsRequired(false);

            modelBuilder.Entity<Medical>()
                     .HasOne(p => p.CreatedUser)
                     .WithMany(b => b.MedicalsCreateds)
                     .HasForeignKey(t => t.CreatedUserId)
                     .OnDelete(DeleteBehavior.NoAction)
                     .IsRequired(false);

            modelBuilder.Entity<Medical>()
                     .HasOne(p => p.ModifyUser)
                     .WithMany(b => b.MedicalModifies)
                     .HasForeignKey(t => t.ModifyUserId)
                     .OnDelete(DeleteBehavior.NoAction)
                     .IsRequired(false);

            //Specialties 
            //modelBuilder.Entity<Medical>().HasMany(p => p.Specialties).WithMany(p => p.Medicals).UsingEntity(j => j.ToTable("MedicalSpecialties"));

            #endregion Medical
        }

        private void generateMock(ModelBuilder modelBuilder)
        {
            string valorbr = new CultureInfo("pt-BR").Name;
            #region MOCK

            #region Gender
            modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, Description = "Masculino", Language = valorbr },
            new Gender { Id = 2, Description = "Feminino", Language = valorbr }
            );
            #endregion

            #region Office

            List<Office> officeAdd = new List<Office>();
            officeAdd.Add(new Office { Id = 1, Description = "Psicólogo", Language = valorbr });
            officeAdd.Add(new Office { Id = 2, Description = "Psicóloga", Language = valorbr });
            officeAdd.Add(new Office { Id = 3, Description = "Clínico", Language = valorbr });

            modelBuilder.Entity<Office>().HasData(officeAdd);

            #endregion

            #region Specialty
            var specialtySAdd = new List<Specialty>();

            specialtySAdd.Add(new Specialty { Id = 1, Description = "Psicologia Clínica", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 2, Description = "Psicologia Social", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 3, Description = "Psicologia educacional", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 4, Description = "Psicologia Esportiva ", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 5, Description = "Psicologia organizacional", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 6, Description = "Psicologia hospitalar", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 7, Description = "Psicologia do trânsito", Language = valorbr });

            modelBuilder.Entity<Specialty>().HasData(specialtySAdd);
            #endregion Specialty

            #region RoleGroup
            List<RoleGroup> rolesAdd = new List<RoleGroup>();
            rolesAdd.Add(new RoleGroup { Id = 1, Description = "Administrador", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 2, Description = "Medico", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 3, Description = "Recepcionista", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 4, Description = "Paciente", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 5, Description = "Leitura", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 6, Description = "Escrita", Language = valorbr });

            modelBuilder.Entity<RoleGroup>().HasData(rolesAdd);
            #endregion RoleGroup

            #region User

            var newAddUser = new User
            {
                Id = 1,
                Name = "User MOCK ",
                Login = "admin",
                Admin = true,
                Email = "admin@sistemas.com",
                CreatedDate = DateTime.Now,
                Enable = true,
                LastAccessDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Role = "Admin",

            };
            SecurityHelper.CreatePasswordHash("mock123adm", out byte[] passwordHash, out byte[] passwordSalt);
            newAddUser.PasswordHash = passwordHash;
            newAddUser.PasswordSalt = passwordSalt;

            newAddUser.RoleGroups = new List<RoleGroup>(); 

            modelBuilder.Entity<User>().HasData(newAddUser);

            var newAddUserMedical = new User
            {
                Id = 2,
                Name = "User Medical",
                Login = "doctor",
                Admin = false,
                Email = "doctor@sistemas.com",
                CreatedDate = DateTime.Now,
                Enable = true,
                LastAccessDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Role = "Medical",

            };
            SecurityHelper.CreatePasswordHash("doctor123", out byte[] passwordHashM, out byte[] passwordSaltM);
            newAddUserMedical.PasswordHash = passwordHashM;
            newAddUserMedical.PasswordSalt = passwordSaltM;

            modelBuilder.Entity<User>().HasData(newAddUserMedical);

            modelBuilder.Entity<User>().HasMany(p => p.RoleGroups).WithMany(p => p.Users).UsingEntity(j => j.HasData(new
            { RoleGroupsId = (long)1, UsersId = (long)1 }));
             
            #endregion

            #region Medical
            var medicalSpecialtyS = new List<Specialty>();
            medicalSpecialtyS.Add(specialtySAdd.First());

            var newAddMedical = new Medical
            {
                Id = 1,
                Name = "Medical MOCK ",
                Email = "medical@sistemas.com",
                CreatedDate = DateTime.Now,
                Enable = true,
                LastAccessDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Accreditation = "123456",
                TypeAccreditation = Domains.Enuns.ETypeAccreditation.CRM,
                OfficeId = 3,
                CreatedUserId = 1,
                UserId = 2, 
            };
            modelBuilder.Entity<Medical>().HasMany(p => p.Specialties).WithMany(p => p.Medicals).UsingEntity(j => j.HasData(new
            { SpecialtiesId = (long)1, MedicalsId = (long)1 }));
             
            modelBuilder.Entity<Medical>().HasData(newAddMedical);

            #endregion Medical

            #endregion MOCK
        }
    }
}