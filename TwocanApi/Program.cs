
using TwocanApi.Repositories;
using TwocanApi.Services;
using TwocanApi.Data;
using Microsoft.EntityFrameworkCore;

namespace TwocanApi
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

            //builder.Services.AddSingleton<IRepository, MemoryRepository>();
            //builder.Services.AddSingleton<IService, Service>();

            builder.Services.AddScoped<IRepository, SqlRepository>();
            builder.Services.AddScoped<IService, Service>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection2"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
            .SetIsOriginAllowed(origin => true));// Allow any origin 

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
