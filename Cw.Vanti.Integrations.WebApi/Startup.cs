//----------------------------------------------------
// <copyright file="Startup.cs" company="Consware">
//     All rights reserved.
// </copyright>
// <author></author>
// <date></date>
// <summary>Definici�n de atributos para la clase Startup.</summary>
//----------------------------------------------------

namespace Cw.Vanti.Integrations.WebApi
{
    using Cw.Vanti.Integrations.DtoModel;
    using Cw.Vanti.Integrations.Negocio;
    using Cw.Vanti.Integrations.Utils;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerUI;
    using System;
    using System.Linq;
    using System.Text;
    using WebAPI;

    /// <summary>
    /// Clase encargada de configurar lo necesario al 
    /// momento de ejecutar backend
    /// </summary>
    public class Startup
    {
        #region Attributes

        /// <summary>
        /// Nombre de la politica para permitir los cors.
        /// </summary>
        private readonly string allowSpecificOrigins = "_allowSpecificOrigins";

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets objeto que contiene las configuraciones del Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Metodo encargado de configurar todos los servicios
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            IConfigurationSection originsSection = this.Configuration.GetSection("Origins");
            var origins = originsSection.GetChildren().ToArray().Select(c => c.Value).ToArray();

            // Se aplica la configuracion de los Cors.
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(allowSpecificOrigins, builder =>
            //    {
            //        builder.WithOrigins(origins)
            //        .AllowAnyHeader()
            //        .AllowAnyMethod()
            //        .AllowCredentials();
            //    });
            //});

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatterNamespace());
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                options.OutputFormatters.RemoveType<TextOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            this.ApplySwaggerConfiguration(services);
            this.AutoMapperConfiguration(services);
            this.AddScopeService(services);
            this.AddTransientService(services);
            this.JwtConfigConfiguration(services);

            services.AddSingleton(_ => this.Configuration);

        }

        /// <summary>
        /// Metodo encargado de configurar los endponints
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "integraciones-vanti/api/docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Integraciones Vanti v1");
                c.RoutePrefix = "integraciones-vanti/api/docs";
                c.DocExpansion(DocExpansion.None);
            });

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }


            app.UseRouting();
            app.UseCors(allowSpecificOrigins);
            // app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Metodo usado para aplicar las configuraciones al gestor de la documentacion
        /// del api(Swagger).
        /// </summary>
        /// <param name="services">Es usado para configurar el api.</param>
        private void ApplySwaggerConfiguration(IServiceCollection services)
        {
            SwaggerConfig swaggerConfig = Configuration.GetSection("SwaggerConfig").Get<SwaggerConfig>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerConfig.VersionWebApi, new OpenApiInfo { Description = swaggerConfig.DescripcionWebApi, Title = swaggerConfig.NombreWebApi + " - " + swaggerConfig.Enviroment, Version = swaggerConfig.VersionWebApi });
                c.OperationFilter<OperationFilters>();
                c.AddSecurityDefinition(swaggerConfig.TipoAutorizacion, new OpenApiSecurityScheme
                {
                    Description = swaggerConfig.DescripcionAutorizacion,
                    Name = swaggerConfig.NombreAutorizacion,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = swaggerConfig.TipoAutorizacion
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = swaggerConfig.TipoAutorizacion
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        /// <summary>
        /// Metodo usado para a�adir los servicios del automapper.
        /// </summary>
        /// <param name="services">Es usado para configurar el automapper.</param>
        private void AutoMapperConfiguration(IServiceCollection services)
        {
            services.AddAutoMapper(conf =>
            {
                #region seguridad

                #endregion

                #region generales


                #endregion

                #region aplicacion



                #endregion

                #region maestrosPrincipales

                #endregion


            }, typeof(Startup));
        }

        /// <summary>
        /// Metodo usado para a�adir los servicios del automapper.
        /// </summary>
        /// <param name="services">Es usado para configurar el automapper.</param>
        private void JwtConfigConfiguration(IServiceCollection services)
        {
            JwtTokenConfig jwtTokenConfig = Configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
            {
                jwtBearerOptions.RequireHttpsMetadata = false;
                jwtBearerOptions.SaveToken = true;
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    SaveSigninToken = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.SecretKey))
                };
            });
        }

        /// <summary>
        /// Metodo usado para a�adir los servicios transitorios al web api.
        /// </summary>
        /// <param name="services">Es usado para configurar el api.</param>
        private void AddTransientService(IServiceCollection services)
        {

            services.AddTransient<NegocioBL>();

            services.AddTransient<IRestauramteBL, RestauranteBL>();
            #endregion

            #region generales

            #endregion

            #region aplicacion

            #endregion

            #region maestrosPrincipales

            services.AddTransient<IUsuarioBL, UsuarioBL>();
            services.AddTransient<UtilHttpClient>();

            #endregion

            #region Facade

            #endregion
        }

        /// <summary>
        /// Metodo usado para a�adir los scope's al servicio del web api.
        /// </summary>
        /// <param name="services">Es usado para configurar el api.</param>
        private void AddScopeService(IServiceCollection services)
        {
            services.AddScoped<TokenValidate>();
        }
    }
}