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
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}

        var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
        builder.WebHost.UseUrls($"http://*:{port}");

        //Get swagger.json following root directory
        app.UseSwagger(options => { options.RouteTemplate = "{documentName}/swagger.json"; });
        //Load swagger.json following root directory
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/v1/swagger.json", "CoffeeStore.API V1"); c.RoutePrefix = string.Empty; });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}