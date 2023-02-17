using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SmartDigitalPsico.Bussines.Contracts.Principals;
using SmartDigitalPsico.Bussines.Principals;
using SmartDigitalPsico.Model.Mapper;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Contract.SystemDomains;
using SmartDigitalPsico.Repository.Principals;
using SmartDigitalPsico.Repository.SystemDomains;
using SmartDigitalPsico.Services.Contracts;
using SmartDigitalPsico.Services.Principals;
using Swashbuckle.AspNetCore.Filters;

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
            services.AddControllers();

            addDoc(services);

           // services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(AutoMapperProfile));


            addRepositories(services);
            addBussines(services);
            addServices(services);

            addORM(services);
            addSecurity(services);
            addDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDigitalPsico.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region INTERFACES
        private void addRepositories(IServiceCollection services)
        {
            //services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMedicalRepository, MedicalRepository>();

            services.AddScoped<IGenderRepository, GenderRepository>();
        }
        private void addBussines(IServiceCollection services)
        {
            services.AddScoped<IUserBussines, UserBussines>();
            services.AddScoped<IMedicalBussines, MedicalBussines>();
            services.AddScoped<IGenderBussines, GenderBussines>();
        }

        private void addServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>(); 
            services.AddScoped<IMedicalService, MedicalService>();
            services.AddScoped<IGenderServices, GenderService>();
        }

        private void addDependencies(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
        }
        #endregion 
    }
}
