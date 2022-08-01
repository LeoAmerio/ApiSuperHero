using Microsoft.OpenApi.Models;
using Npgsql;
using SuperHeroApi.Data;
using SuperHeroApi.Repositories;
using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;
using Microsoft.Extensions.DependencyInjection;

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
            var postgreSQL = Configuration.GetConnectionString("HeroDb");
            services.AddDbContext<HeroesDb>(options =>
            options.UseNpgsql(postgreSQL));
            
            services.AddSingleton(postgreSQL);
            //services.AddTransient<SuperHero>(new SuperHero());
            //services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(postgreSQL.ConnectionString));
            services.AddTransient<ISuperHeroRepo, SuperHeroRepo>();

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

            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

        }
    }
}
