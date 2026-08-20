
using AspTask5.Data;
using AspTask5.Middleware;
using Microsoft.EntityFrameworkCore;

namespace AspTask5
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

            var connection = builder.Configuration.GetConnectionString("MyConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connection));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            
            app.UseMiddleware<RequestLoggingMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
