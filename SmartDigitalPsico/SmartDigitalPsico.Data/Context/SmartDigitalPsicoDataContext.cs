
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

        public DbSet<User> Users { get; set; }

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
            string valorbr = new CultureInfo("pt-BR").Name;

            modelBuilder.Entity<Patient>().Property(b => b.Profession).IsRequired(false);//optinal case

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

            modelBuilder.Entity<Specialty>().HasData(
              new Specialty { Id = 1, Description = "Psicologia Clínica", Language = valorbr },
              new Specialty { Id = 2, Description = "Psicologia Social", Language = valorbr },
              new Specialty { Id = 3, Description = "Psicologia educacional", Language = valorbr },
              new Specialty { Id = 4, Description = "Psicologia Esportiva ", Language = valorbr },
              new Specialty { Id = 5, Description = "Psicologia organizacional", Language = valorbr },
              new Specialty { Id = 6, Description = "Psicologia hospitalar", Language = valorbr },
              new Specialty { Id = 7, Description = "Psicologia do trânsito", Language = valorbr }
              );
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
            //newAddUser.RoleGroups.Add(rolesAdd.First(et => et.Id == 1));

            modelBuilder.Entity<User>().HasData(newAddUser);
            #endregion 

            #region Medical

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
                //CreatedUser = newAddUser,
                OfficeId = 3,                
                CreatedUserId = 1 
            };

            modelBuilder.Entity<Medical>().HasData(newAddMedical);

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



            #endregion Medical

            #endregion MOCK

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


            //modelBuilder.Entity<User>()
            //   .HasMany(p => p.RoleGroups)
            //   .WithMany(t => t.Users)
            //   .UsingEntity<Dictionary<string, object>>(
            //       "UserRoleGroup",  
            //    r => r.HasOne<User>().WithMany().HasForeignKey("RoleId"),

            //       l => l.HasOne<RoleGroup>().WithMany().HasForeignKey("UserId") );



            base.OnModelCreating(modelBuilder);
        }
    }
}