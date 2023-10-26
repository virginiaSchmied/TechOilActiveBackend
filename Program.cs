using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using TechOilActive.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer;
using TechOilActive.Controllers;
using TechOilActive.Interfaces;
using TechOilActive.Repositorios;

namespace TechOilActive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthorization();
            // Add configuration from appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            builder.Services.AddDbContext<MyDbContext>();
            builder.Services.AddScoped<InterfaceProyectos, RepositorioProyecto>();
            builder.Services.AddScoped<InterfaceTrabajos, RepositorioTrabajo>();
            builder.Services.AddScoped<InterfaceServicios, RepositorioServicio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            IConfiguration configuration = app.Configuration;

            IWebHostEnvironment environment = app.Environment;

            app.MapControllers();

            app.Run();
        }
    }
}