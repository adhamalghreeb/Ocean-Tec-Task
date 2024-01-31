using Microsoft.EntityFrameworkCore;
using Ocean_Tec_Task;
using Ocean_Tec_Task.Service;
using Ocean_Tec_Task.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<dbContextClass>(optinons =>
optinons.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(MappingProfile)); 

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
