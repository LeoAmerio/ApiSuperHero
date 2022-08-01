using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using Npgsql;
using System.Data;
using System.Configuration;
using SuperHeroApi;

/*
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new HeroesDb(builder.Configuration.GetConnectionString("HeroDB"));
services.AddSingleton(configuration);
services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(configuration.ConnectionString));
 
var connection = builder.Configuration.GetConnectionString("HeroDB");
builder.Services.AddDbContext<HeroesDb>(options => 
options.UseNpgsql(connection));
builder.Services.AddDbContext<HeroesDb>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("HeroDb"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();*/

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

