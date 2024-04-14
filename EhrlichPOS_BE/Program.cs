using EhrlichPOS_BE;
using EhrlichPOS_BE.Interfaces;
using EhrlichPOS_BE.Models;
using EhrlichPOS_BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IPizzaType, PizzaTypeService>();
builder.Services.AddScoped<IPizza, PizzaService>();
builder.Services.AddScoped<IOrder, OrderService>();

var connectionString = $"Data Source=.;Initial Catalog=EhrlichPOS; Integrated Security=True; TrustServerCertificate=True";
builder.Services.AddDbContext<EhrlichPosContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddEndpointsApiExplorer();

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
