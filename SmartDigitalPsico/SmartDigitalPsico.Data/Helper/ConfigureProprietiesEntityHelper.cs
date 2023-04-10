using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using System;

namespace SmartDigitalPsico.Repository.Helper
{
    internal static class ConfigureProprietiesEntity
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(b => b.Profession).IsRequired(false);//optinal case 

            //Composite index
            modelBuilder.Entity<ApplicationLanguage>()
                .HasIndex(p => new { p.ResourceKey, p.Language, p.LanguageKey })
                .HasDatabaseName("Idx_ApplicationLanguage_ResourceKey_Language_LanguageKey_Unique")
                .IsUnique();  
        }
    }
}
