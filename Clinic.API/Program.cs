using Microsoft.Extensions.DependencyInjection;
using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Clinic.Data.Repositories;
using Mirpaha.Clinic.Service;
using Mirpaha.Clinic.Core.Services;
using System.Text.Json.Serialization;
using Clinic.API.Mapping;
using Clinic.Core;

namespace Mirpaha.Clinic.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>();
            //builder.Services.AddSingleton<DataContext>();
            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IAppointmentService, AppointmentService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(ApiMappingProfile));


            //להוסיף כאן
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}