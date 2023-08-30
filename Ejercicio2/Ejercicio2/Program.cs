using Ejercicio2.Data;
using Ejercicio2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios que se agregarán al contenedor de inyección de dependencias.
builder.Services.AddControllers();
// Obtén más información sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la base de datos
builder.Services.AddDbContext<AppDbContext>();

// Agrega las implementaciones de los repositorios al contenedor de inyección de dependencias.
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

var app = builder.Build();

// Configura la canalización de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger para la documentación de la API en entornos de desarrollo.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirige las solicitudes HTTP a HTTPS si es necesario.
app.UseHttpsRedirection();

// Aplica autorización a las solicitudes.
app.UseAuthorization();

// Mapea las rutas de los controladores.
app.MapControllers();

// Ejecuta la aplicación.
app.Run();
