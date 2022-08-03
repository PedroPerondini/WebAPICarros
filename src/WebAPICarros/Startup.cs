using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebAPICarros.Core.Services;
using WebAPICarros.Core.Services.Interfaces;
using WebAPICarros.Domain.Model;
using WebAPICarros.Domain.Model.Interfaces;
using WebAPICarros.Repository;
using WebAPICarros.Repository.Interfaces;

namespace WebAPICarros
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
            services.AddCors();
            services.AddControllers();

            services.Configure<CarroDatabaseSettings>(Configuration.GetSection(nameof(CarroDatabaseSettings)));
            services.Configure<UserDatabaseSettings>(Configuration.GetSection(nameof(UserDatabaseSettings)));
            services.AddSingleton<ICarroDatabaseSettings>(x => x.GetRequiredService<IOptions<CarroDatabaseSettings>>().Value);
            services.AddSingleton<IUserDatabaseSettings>(x => x.GetRequiredService<IOptions<UserDatabaseSettings>>().Value);
            services.AddSingleton<ICarroServices, CarrosServices>();
            services.AddSingleton<ICarroRepository, CarroRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserServices, UserServices>();
            services.AddSingleton<ITokenServices, TokenServices>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPICarros", Version = "v1" });
            });

            var secret = Encoding.ASCII.GetBytes(JwtTokenSetting.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secret),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPICarros v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
