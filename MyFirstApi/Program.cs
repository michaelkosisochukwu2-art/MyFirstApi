using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using MyFirstApi.Repository;
using System;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Register your repository

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped < IDepartmentRepository, DepartmentRepository>();



var app = builder.Build();
app.UseCors(builder => builder.WithOrigins("http://localhost:3000")
.AllowAnyHeader()
.AllowAnyMethod());


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
