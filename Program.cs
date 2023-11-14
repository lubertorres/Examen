using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISeat, SeatP>();
builder.Services.AddScoped<IMovies, MoviesP>();
builder.Services.AddScoped<IBilboardEntity, BilboardP>();
builder.Services.AddScoped<IRoomEntity, RoomEntityP>();
builder.Services.AddScoped<ICustomerEntity, CustomerP>();
builder.Services.AddScoped<IBookinEntity, BookingP>();


IConfiguration config = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
      .AddEnvironmentVariables()
      .Build();

builder.Services.AddDbContext<BaseEntityContext>(options =>
    options.UseSqlServer(config.GetConnectionString("cn")));


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
