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
    options.UseNpgsql($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}", opt =>
    {
        opt.CommandTimeout(180);
        opt.EnableRetryOnFailure(5);
    });
});
//options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<PostgresContext>();
builder.Services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IBaseService<User>, BaseService<User>>();


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
