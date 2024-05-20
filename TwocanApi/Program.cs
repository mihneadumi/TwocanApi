using Microsoft.EntityFrameworkCore;
using TwocanApi.Data;
using TwocanApi.Repositories;
using TwocanApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TwocanApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IRepository, SqlRepository>();
            builder.Services.AddScoped<IService, Service>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection2"));
            });

            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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
                .SetIsOriginAllowed(origin => true));

            app.UseAuthorization();

            app.UseSession();

            // Add middleware to the pipeline
            app.UseMiddleware<TokenValidationMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
