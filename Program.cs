using task1.Interfaces;
using task1.Repos;
using Microsoft.EntityFrameworkCore;
using task1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Task1Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
); 

builder.Services.AddCors( policy=>
        {policy.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());});

//Interfaces
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

builder.Services.AddControllers(); // This registers your controllers

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseRouting(); // Enables routing middleware
app.UseCors("AllowOrigin");
app.UseAuthorization(); // Enables authorization middleware

app.MapControllers(); // Maps controller routes to be accessible


app.Run();

