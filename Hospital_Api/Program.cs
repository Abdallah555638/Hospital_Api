

using Microsoft.EntityFrameworkCore;
using Hospital_Api.Data;
using Hospital_Api.Helper;
using Hospital_Api.Repo;
using Hospital_Api.Controllers;

namespace Hospital_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<App_DbContext>
             (option => option.UseSqlServer
             (builder.Configuration.GetConnectionString("Defult")));
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped(typeof(IGenaric<>), typeof(Genaric<>));
            builder.Services.AddScoped<PatientRepo>();
            builder.Services.AddScoped<DoctorRepo>();
            builder.Services.AddAutoMapper(typeof(ProfileMapping));
            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                        if (app.Environment.IsDevelopment())
{
};

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                        

            app.Run();
        }
    }
}
