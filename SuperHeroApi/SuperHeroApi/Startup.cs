using Microsoft.OpenApi.Models;
using Npgsql;
using SuperHeroApi.Data;
using SuperHeroApi.Repositories;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;


namespace SuperHeroApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var postgresql = new HeroesDb(Configuration.GetConnectionString("PostgreSQLConnection"));
            services.AddSingleton(postgresql);
            services.AddScoped<ISuperHeroRepo, SuperHeroRepo>();
            services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(postgresql.ConnectionString));
            
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SuperHero", Version = "v1" });
            });

            services.AddEndpointsApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
