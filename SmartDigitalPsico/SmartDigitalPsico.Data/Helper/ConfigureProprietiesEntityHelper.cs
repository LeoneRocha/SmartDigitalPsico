using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
