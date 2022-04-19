using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Service.Services;
using Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostgresContext>(options =>
{
    var server = "localhost";
    var port = "5432";
    var database = "CRUDS";
    var username = "postgres";
    var password = "postgres";
    options.UseNpgsql($"Server={server};Port={port};Database={database};User Id={username};Password={password}", opt =>
    {
    }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IBaseRepository<Users>, BaseRepository<Users>>();
builder.Services.AddScoped<IBaseService<Users>, BaseService<Users>>();
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
