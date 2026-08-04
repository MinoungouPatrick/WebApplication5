using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

using Scalar.AspNetCore;
using WebApplication5;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ITodoService, TodoService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
    
    app.MapControllers();

    app.MapOpenApi();

    app.MapScalarApiReference();
    
    app.Run();