
using DBCreation.Application.Models;
using DBCreation.Application.Services;
using DBCreation.Persistence.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace DBCreation.Service
{
    public class Program
    {
        public Program()
        {
            Console.WriteLine("Program is worked");
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            builder.Services.AddScoped<IOperations, DMLOperations>();
            
            builder.Services.AddDbContext<MakeConnections>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("str")));

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
