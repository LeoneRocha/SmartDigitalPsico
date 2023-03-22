using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains.AddVOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.Helper
{
    internal static class DataMockHelper
    {
        static string valorbr = new CultureInfo("pt-BR").Name;
        internal static void GenerateMock(ModelBuilder modelBuilder)
        {
            #region ApplicationConfigSetting
            addMockApplicationConfigSetting(modelBuilder);
            #endregion

            #region ApplicationLanguage
            addMockApplicationLanguage(modelBuilder);
            #endregion

            #region Gender
            addMockGender(modelBuilder);
            #endregion

            #region Office
            addMockOffice(modelBuilder);
            #endregion

            #region Specialty
            List<Specialty> specialtySAdd = addMockSpecialty(modelBuilder);
            #endregion Specialty

            #region RoleGroup

            addMockRoleGroup(modelBuilder);

            #endregion RoleGroup

            #region User

            addMockUser(modelBuilder);
            #endregion

            #region Medical

            addMockMedical(modelBuilder, specialtySAdd);

            #endregion Medical

        }

        private static void addMockApplicationLanguage(ModelBuilder modelBuilder)
        {
            List<ApplicationLanguage> addRegisters = new List<ApplicationLanguage>();
            addRegisters.Add(gerateNewLanguage(1, "Default", valorbr, "Default_ptbr", "Padrão"));
            modelBuilder.Entity<ApplicationLanguage>().HasData(addRegisters);
        }

        private static ApplicationLanguage gerateNewLanguage(long id, string description, string valueLanguage, string languageKey, string languageValue)
        {
            return new ApplicationLanguage
            {
                Id = id,
                Description = description,
                Language = valueLanguage,
                LanguageKey = languageKey,
                LanguageValue = languageValue,
                CreatedDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                LastAccessDate = DateTime.Now,
                Enable = true,
            };
        }

        private static void addMockApplicationConfigSetting(ModelBuilder modelBuilder)
        {
            List<ApplicationConfigSetting> addRegisters = new List<ApplicationConfigSetting>();
            addRegisters.Add(new ApplicationConfigSetting
            {
                Id = 1,
                Description = "Default",
                Language = valorbr,
                CreatedDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                LastAccessDate = DateTime.Now,
                TypeLocationCache = Domains.Enuns.ETypeLocationCache.Memory,
                TypeLocationSaveFiles = Domains.Enuns.ETypeLocationSaveFiles.DataBase,
                TypeLocationQueeMessaging = Domains.Enuns.ETypeLocationQueeMessaging.MongoDB,
                EndPointUrl_Cache = string.Empty,
                EndPointUrl_StorageFiles = string.Empty,
                Enable = true,
            });
            modelBuilder.Entity<ApplicationConfigSetting>().HasData(addRegisters);
        }

        private static void addMockMedical(ModelBuilder modelBuilder, List<Specialty> specialtySAdd)
        {
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
            };
            modelBuilder.Entity<Medical>().HasMany(p => p.Specialties).WithMany(p => p.Medicals).UsingEntity(j => j.HasData(new
            { SpecialtiesId = (long)1, MedicalsId = (long)1 }));

            modelBuilder.Entity<Medical>().HasData(newAddMedical);

        }

        private static void addMockUser(ModelBuilder modelBuilder)
        {

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

            modelBuilder.Entity<User>().HasMany(p => p.RoleGroups).WithMany(p => p.Users).UsingEntity(j => j.HasData(
                new { RoleGroupsId = (long)1, UsersId = (long)1 }, 
                new { RoleGroupsId = (long)5, UsersId = (long)1 },
                new { RoleGroupsId = (long)5, UsersId = (long)2 },
                new { RoleGroupsId = (long)6, UsersId = (long)1 },
                new { RoleGroupsId = (long)6, UsersId = (long)2 }));

        }

        private static void addMockRoleGroup(ModelBuilder modelBuilder)
        {
            List<RoleGroup> rolesAdd = new List<RoleGroup>();
            rolesAdd.Add(new RoleGroup { Id = 1, RolePolicyClaimCode = "Admin", Description = "Administrador", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 2, RolePolicyClaimCode = "Medical", Description = "Medico", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 3, RolePolicyClaimCode = "Staff", Description = "Recepcionista", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 4, RolePolicyClaimCode = "Patient", Description = "Paciente", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 5, RolePolicyClaimCode = "Read", Description = "Leitura", Language = valorbr });
            rolesAdd.Add(new RoleGroup { Id = 6, RolePolicyClaimCode = "Write", Description = "Escrita", Language = valorbr });

            modelBuilder.Entity<RoleGroup>().HasData(rolesAdd);
        }

        private static List<Specialty> addMockSpecialty(ModelBuilder modelBuilder)
        {
            var specialtySAdd = new List<Specialty>();

            specialtySAdd.Add(new Specialty { Id = 1, Description = "Psicologia Clínica", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 2, Description = "Psicologia Social", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 3, Description = "Psicologia educacional", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 4, Description = "Psicologia Esportiva ", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 5, Description = "Psicologia organizacional", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 6, Description = "Psicologia hospitalar", Language = valorbr });
            specialtySAdd.Add(new Specialty { Id = 7, Description = "Psicologia do trânsito", Language = valorbr });

            modelBuilder.Entity<Specialty>().HasData(specialtySAdd);

            return specialtySAdd;
        }

        private static void addMockOffice(ModelBuilder modelBuilder)
        {
            List<Office> officeAdd = new List<Office>();
            officeAdd.Add(new Office { Id = 1, Description = "Psicólogo", Language = valorbr });
            officeAdd.Add(new Office { Id = 2, Description = "Psicóloga", Language = valorbr });
            officeAdd.Add(new Office { Id = 3, Description = "Clínico", Language = valorbr });

            modelBuilder.Entity<Office>().HasData(officeAdd);
        }

        private static void addMockGender(ModelBuilder modelBuilder)
        {
            #region Gender
            modelBuilder.Entity<Gender>().HasData(
            new Gender { Id = 1, Description = "Masculino", Language = valorbr },
            new Gender { Id = 2, Description = "Feminino", Language = valorbr }
            );
            #endregion
        }
    }
}
