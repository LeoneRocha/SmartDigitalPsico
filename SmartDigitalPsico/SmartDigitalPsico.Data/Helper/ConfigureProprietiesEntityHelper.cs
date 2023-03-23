using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;

namespace SmartDigitalPsico.Repository.Helper
{
    internal static class ConfigureProprietiesEntity
    {
        internal static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().Property(b => b.Profession).IsRequired(false);//optinal case 
        }
    }
}
