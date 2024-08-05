
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SITS.Application.Models;
using SITS.Application.Operations;
using SITS.Application.Validators;
using SITS.Domain.Entities;
using SITS.Persistence.DBContexts;

namespace SITS.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<MakeConnection>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("str")));
            builder.Services.AddCors(option => option.AddDefaultPolicy(option => option.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            builder.Services.AddScoped<IRequestAndResponse, RequestAndResponse>();
            builder.Services.AddScoped<IValidator<Student>, StudentValidations>();
            builder.Services.AddScoped<IValidator<StudentDetail>, StudentDetailsValidations>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
