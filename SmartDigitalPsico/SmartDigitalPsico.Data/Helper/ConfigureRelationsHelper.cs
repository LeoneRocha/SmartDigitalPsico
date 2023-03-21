using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
