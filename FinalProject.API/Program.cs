using FinalProject.BL;
using FinalProject.BL.Services;
using FinalProject.DAL;
using FinalProject.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using FinalProject.Common;

string currentDir = AppContext.BaseDirectory;
while (currentDir != null && Directory.GetFiles(currentDir, "*.sln").Length == 0)
{
    currentDir = Directory.GetParent(currentDir)?.FullName;
}
if (currentDir != null)
{
    AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(currentDir, "DB"));
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.RegisterSystemServices(connectionString);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FinalProject.DAL.AppDbContext>();
    context.Database.EnsureCreated();
}

app.Run();
