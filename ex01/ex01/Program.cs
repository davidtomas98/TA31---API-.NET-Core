using ex01.Data;
using ex01.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor de inyección de dependencias.
builder.Services.AddControllers();

// Aprende más sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la base de datos.
builder.Services.AddDbContext<AppDbContext>();

// Agregar la dependencia del repositorio de clientes.
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

var app = builder.Build();

// Configurar el flujo de solicitud HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilitar Swagger y Swagger UI solo en el entorno de desarrollo.
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
