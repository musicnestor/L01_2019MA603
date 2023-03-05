using L01_2019MA603.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using L01_2019MA603.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Inyección por dependencia
builder.Services.AddDbContext<clientesContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("clientesDbConnection")
    )

);

//AQUI TERMINA LA INYECCION DE 

builder.Services.AddSwaggerGen();

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
