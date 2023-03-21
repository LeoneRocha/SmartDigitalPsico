using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.Helper
{
    internal static class ConfigureDefaultValuesHelper
    {
        static bool valorPadraoEnable = true;
        internal static void Configure(ModelBuilder modelBuilder)
        {
            addConfigureDefaultValues_User(modelBuilder);
            addConfigureDefaultValues_Gender(modelBuilder);
            addConfigureDefaultValues_Specialty(modelBuilder);
            addConfigureDefaultValues_Office(modelBuilder);
            addConfigureDefaultValues_RoleGroup(modelBuilder);
            addConfigureDefaultValues_Medical(modelBuilder);
            addConfigureDefaultValues_Patient(modelBuilder);
            addConfigureDefaultValues_PatientAdditionalInformation(modelBuilder);
            addConfigureDefaultValues_PatientHospitalizationInformation(modelBuilder);
            addConfigureDefaultValues_PatientMedicationInformation(modelBuilder);
            addConfigureDefaultValues_PatientNotificationMessage(modelBuilder);
            addConfigureDefaultValues_PatientRecord(modelBuilder);

        }
        private static void addConfigureDefaultValues_PatientRecord(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientRecord>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_PatientNotificationMessage(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientNotificationMessage>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_PatientMedicationInformation(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PatientMedicationInformation>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_PatientHospitalizationInformation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientHospitalizationInformation>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_PatientAdditionalInformation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientAdditionalInformation>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_Patient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_Medical(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medical>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_RoleGroup(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleGroup>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_Office(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_Specialty(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_Gender(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }

        private static void addConfigureDefaultValues_User(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("Admin");
            modelBuilder.Entity<User>().Property(u => u.Enable).HasDefaultValue(valorPadraoEnable);
        }
    }
}
