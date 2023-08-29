using System;
using ex03.Data;
using ex03.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger services for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context
builder.Services.AddDbContext<AppDbContext>();

// Add scoped repositories to the service container
builder.Services.AddScoped<IAsignadoRepository, AsignadoRepository>();
builder.Services.AddScoped<ICientificoRepository, CientificoRepository>();
builder.Services.AddScoped<IProyectoRepository, ProyectoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI for API documentation in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Map API controller routes
app.MapControllers();

app.Run();
