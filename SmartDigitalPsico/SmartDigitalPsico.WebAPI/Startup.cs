using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SmartDigitalPsico.Domains.Enuns;
using SmartDigitalPsico.Model.Mapper;
using SmartDigitalPsico.Model.VO.Domains;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.WebAPI.Helper;
using Swashbuckle.AspNetCore.Filters;
using System.IO;

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
            //For In-Memory Caching
            addCaching(services);

            //Security API
            addSecurity(services);

            //AcceptHeader 
            services.AddControllers();

            //CORS
            addCors(services);

            //AcceptHeader 
            addAcceptHeader(services);

            //HyperMediaFilterOptions
            HyperMediaHelper.AddHyperMedia(services);

            //Documenacao
            addDoc(services);

            // Auto Mapper 
            services.AddAutoMapper(typeof(AutoMapperProfile));

            //ORM API
            addORM(services, TypeDataBase.MSsqlServer);

            //Versioning API
            addVersionning(services);

            //Dependency Injection
            DependenciesInjectionHelper.AddDependenciesInjection(services);
        }

        private void addCaching(IServiceCollection services)
        {
            services.Configure<CacheConfigurationVO>(Configuration.GetSection("CacheConfiguration"));
            services.AddMemoryCache();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //// Migrate latest database changes during startup
            addAutoMigrate(app);

            app.UseHttpsRedirection(); 

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"ResourcesTemp")),
                RequestPath = new PathString("/ResourcesTemp")
            });

            app.UseRouting();

            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDigitalPsico.WebAPI v1"));

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //HyperMedia
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });


        }

        #region PRIVATES

        #region AcceptHeader
        private void addAcceptHeader(IServiceCollection services)
        {
            //AcceptHeader
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters();
        }
        #endregion

        #region Cors
        private void addCors(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
        }
        #endregion

        #region Version
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
        #endregion

        #region CONTEXTO
        private void addORM(IServiceCollection services, TypeDataBase etypeDataBase)
        {
            var connection = string.Empty;

            switch (etypeDataBase)
            {
                case TypeDataBase.Mysql:
                    connection = Configuration.GetConnectionString("SmartDigitalPsicoDBConnectionMySQL");
                    services.AddDbContext<SmartDigitalPsicoDataContext>(options =>
                    options.UseMySql(connection, ServerVersion.AutoDetect(connection)
                    , b =>
                    {
                        b.MigrationsAssembly("SmartDigitalPsico.WebAPI");
                        b.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    }));
                    //migreted = _Environment.IsDevelopment() ? migrateDatabaseMySql(connection) : false;
                    break;
                case TypeDataBase.MSsqlServer:
                    connection = Configuration.GetConnectionString("SmartDigitalPsicoDBConnection");
                    services.AddDbContext<SmartDigitalPsicoDataContext>(options => options.UseSqlServer(connection,
                        b => b.MigrationsAssembly("SmartDigitalPsico.WebAPI")));
                    break;
                default:
                    break;
            }
        }
        private void addAutoMigrate(IApplicationBuilder app)
        {
            bool migreted = false;
            if (!migreted)
            {
                //// Migrate latest database changes during startup
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<SmartDigitalPsicoDataContext>();
                    context.Database.Migrate();
                }
            }
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

        #endregion
    }
}
