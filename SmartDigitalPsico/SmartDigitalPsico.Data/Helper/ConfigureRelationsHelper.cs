using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Mysqlx.Crud;
using SmartDigitalPsico.Model.Entity.Principals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SmartDigitalPsico.Repository.Helper
{
    internal static class ConfigureRelationsHelper
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            //https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/relationships

            addConfigureMedical(modelBuilder);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            addConfigurePatientChilds(modelBuilder);


        }
        private static void addConfigurePatientChilds(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<InfoTag>()
            //    .HasMany(e => e.Patients)
            //    .WithMany(e => e.InfoTags)
            //    .UsingEntity(
            //    l => l.HasOne(typeof(InfoTag)).WithMany().OnDelete(DeleteBehavior.NoAction),
            //    r => r.HasOne(typeof(Patient)).WithMany().OnDelete(DeleteBehavior.NoAction)); 


            //modelBuilder.Entity<Patient>()
            //    .HasMany(e => e.InfoTags)
            //    .WithMany(e => e.Patients)
            //   .UsingEntity<PatientInfoTag>( 
            //    l => l.HasOne<InfoTag>().WithMany().HasForeignKey(e => e.InfoTagId),
            //    r => r.HasOne<Patient>().WithMany().HasForeignKey(e => e.PatientId));
           
            
            modelBuilder.Entity<PatientInfoTag>()
          .HasKey(t => new { t.PatientId, t.InfoTagId });

            modelBuilder.Entity<PatientInfoTag>()
                .HasOne(pt => pt.Patient)
                .WithMany(p => p.PatientInfoTags)
                .HasForeignKey(pt => pt.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PatientInfoTag>()
                .HasOne(pt => pt.InfoTag)
                .WithMany(t => t.PatientInfoTags)
                .HasForeignKey(pt => pt.InfoTagId)
                .OnDelete(DeleteBehavior.NoAction);


        }
        private static void addConfigureMedical(ModelBuilder modelBuilder)
        {
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

            //configures one-to-one relationship
            modelBuilder.Entity<Medical>()
            .HasOne(b => b.User)
            .WithOne(i => i.Medical)
            .HasForeignKey<User>(b => b.MedicalId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

            // configures one-to-many relationship
            /*modelBuilder.Entity<Medical>()
                  .HasOne(p => p.User)
                  .WithMany(b => b.MedicalsUsers)
                  .HasForeignKey(t => t.UserId)
                  .OnDelete(DeleteBehavior.NoAction)
                  .IsRequired(false);
            */

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
    }
}
