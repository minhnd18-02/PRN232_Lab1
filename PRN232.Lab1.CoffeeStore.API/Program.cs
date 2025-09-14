using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.API;
using PRN232.Lab1.CoffeeStore.Data;
using PRN232.Lab1.CoffeeStore.Infrastructure;
using PRN232.Lab1.CoffeeStore.Infrastructure.Mappers;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddInfrastructuresService();
        builder.Services.AddWebAPIService();
        builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

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