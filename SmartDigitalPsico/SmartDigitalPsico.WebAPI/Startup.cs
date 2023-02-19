using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestWithASPNETUdemy.Hypermedia.Enricher;
using SmartDigitalPsico.Business.Contracts.Principals;
using SmartDigitalPsico.Business.Contracts.SystemDomains;
using SmartDigitalPsico.Business.Principals;
using SmartDigitalPsico.Business.SystemDomains;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Model.Mapper;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Principals;
using SmartDigitalPsico.Repository.SystemDomains;
using SmartDigitalPsico.Services.Contracts.Principals;
using SmartDigitalPsico.Services.Contracts.SystemDomains;
using SmartDigitalPsico.Services.Principals;
using SmartDigitalPsico.Services.SystemDomains;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace SmartDigitalPsico.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Security API
            addSecurity(services);

            //AcceptHeader 
            services.AddControllers();

            //CORS
            addCors(services);

            //AcceptHeader 
            addAcceptHeader(services);

            //Documenacao
            addDoc(services);

            // Auto Mapper 
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //ORM API
            addORM(services);

            //Versioning API
            addVersionning(services);

            //Dependency Injection
            addDependenciesInjection(services);

            //HyperMediaFilterOptions
            addHyperMedia(services);

        }

        private void addHyperMedia(IServiceCollection services)
        {
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new GetGenderVOEnricher());

            services.AddSingleton(filterOptions);
        }

        private void addAcceptHeader(IServiceCollection services)
        {
            //AcceptHeader 
            //services.AddMvc(options =>
            //{
            //    options.RespectBrowserAcceptHeader = true;

            //    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
            //    options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            //})
            //.AddXmlSerializerFormatters();
        }

        private void addCors(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
        }

        private void addDependenciesInjection(IServiceCollection services)
        {
            addRepositories(services);
            addBusiness(services);
            addServices(services);
            addDependencies(services);
        }

        private void addVersionning(IServiceCollection services)
        {
            services.AddApiVersioning();
            //services.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true;
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //}); 
            //services.AddVersionedApiExplorer(options =>
            //{
            //    options.GroupNameFormat = "'v'V";
            //    options.SubstituteApiVersionInUrl = true;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDigitalPsico.WebAPI v1"));

            //var option = new RewriteOptions();
            //option.AddRedirect("^$", "swagger");
             
            // app.UseRewriter(option);
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}"); 
            });
        }

        #region INTERFACES
        private void addRepositories(IServiceCollection services)
        {
            //services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMedicalRepository, MedicalRepository>();

            #region PATIENT
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientRecordRepository, PatientRecordRepository>();
            services.AddScoped<IPatientMedicationInformationRepository, PatientMedicationInformationRepository>();
            services.AddScoped<IPatientHospitalizationInformationRepository, PatientHospitalizationInformationRepository>();
            services.AddScoped<IPatientAdditionalInformationRepository, PatientAdditionalInformationRepository>();
            #endregion PATIENT

            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();

        }
        private void addBusiness(IServiceCollection services)
        {
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IMedicalBusiness, MedicalBusiness>();
            services.AddScoped<IOfficeBusiness, OfficeBusiness>();
            services.AddScoped<IRoleGroupBusiness, RoleGroupBusiness>();
            services.AddScoped<IGenderBusiness, GenderBusiness>();
            services.AddScoped<ISpecialtyBusiness, SpecialtyBusiness>();

            #region PATIENT
            services.AddScoped<IPatientBusiness, PatientBusiness>();
            services.AddScoped<IPatientRecordBusiness, PatientRecordBusiness>();
            services.AddScoped<IPatientMedicationInformationBusiness, PatientMedicationInformationBusiness>();
            services.AddScoped<IPatientHospitalizationInformationBusiness, PatientHospitalizationInformationBusiness>();
            services.AddScoped<IPatientAdditionalInformationBusiness, PatientAdditionalInformationBusiness>();
            #endregion PATIENT 
        }

        private void addServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IMedicalServices, MedicalServices>();
            services.AddScoped<IGenderServices, GenderServices>();
            services.AddScoped<IOfficeServices, OfficeServices>();
            services.AddScoped<IRoleGroupServices, RoleGroupServices>();
            services.AddScoped<ISpecialtyServices, SpecialtyServices>();

            #region PATIENT
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IPatientRecordServices, PatientRecordServices>();
            services.AddScoped<IPatientMedicationInformationServices, PatientMedicationInformationServices>();
            services.AddScoped<IPatientHospitalizationInformationServices, PatientHospitalizationInformationServices>();
            services.AddScoped<IPatientAdditionalInformationServices, PatientAdditionalInformationServices>();
            #endregion PATIENT


        }

        private void addDependencies(IServiceCollection services)
        {
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        #endregion

        #region CONTEXTO
        private void addORM(IServiceCollection services)
        {
            services.AddDbContext<SmartDigitalPsicoDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SmartDigitalPsicoDBConnection"), b => b.MigrationsAssembly("SmartDigitalPsico.WebAPI")));
        }
        #endregion

        #region DOCUMENTACAO
        private void addDoc(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartDigitalPsico.WebAPI", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
        #endregion

        #region SEGURANCA
        private void addSecurity(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                      ValidateIssuer = false,
                      ValidateAudience = false
                  };
              });


            //   services.AddAuthentication(options =>
            //   {
            //       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //   })
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = tokenConfigurations.Issuer,
            //        ValidAudience = tokenConfigurations.Audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
            //    };
            //});

            //   services.AddAuthorization(auth =>
            //   {
            //       auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //           .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            //           .RequireAuthenticatedUser().Build());
            //   });


        }
        #endregion 
    }
}
