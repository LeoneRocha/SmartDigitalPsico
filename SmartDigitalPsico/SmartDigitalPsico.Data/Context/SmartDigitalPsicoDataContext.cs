
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Domains.Security;
using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Domains.Configurations;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Helper;
using System.Configuration;
using System.Globalization;
using System.Reflection.Metadata;

namespace SmartDigitalPsico.Repository.Context
{
    public sealed class SmartDigitalPsicoDataContext : EntityDataContext
    {
        public SmartDigitalPsicoDataContext(DbContextOptions<SmartDigitalPsicoDataContext> options) : base(options)
        {

        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var typeDB = configuration.GetValue<ETypeDataBase>("DataBaseConfigurations:TypeDataBase");

            ConfigureProprietiesEntity.Configure(modelBuilder);

            DataMockHelper.GenerateMock(modelBuilder, typeDB);

            ConfigureRelationsHelper.Configure(modelBuilder);

            ConfigureDefaultValuesHelper.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}