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
using SmartDigitalPsico.Data.Context;
using SmartDigitalPsico.Data.Contract;
using SmartDigitalPsico.Data.Repository;
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

            services.AddAutoMapper(typeof(Startup));

            addServices(services);
            addRepositories(services);

            addORM(services);

            addSecurity(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private void addORM(IServiceCollection services)
        {
            //\\RAZORCREST
            services.AddDbContext<SmartDigitalPsicoDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SmartDigitalPsicoDBConnection"), b => b.MigrationsAssembly("SmartDigitalPsico.WebAPI")));
        }

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

        private void addRepositories(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
        private void addServices(IServiceCollection services)
        {
            //services.AddScoped<ICharacterService, CharacterService>();
            //services.AddScoped<IWeaponService, WeaponService>();
            //services.AddScoped<IFightService, FightService>();

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
    }
}
