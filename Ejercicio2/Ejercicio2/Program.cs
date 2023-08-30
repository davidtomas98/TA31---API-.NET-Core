using Ejercicio2.Data;
using Ejercicio2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura los servicios que se agregar�n al contenedor de inyecci�n de dependencias.
builder.Services.AddControllers();
// Obt�n m�s informaci�n sobre c�mo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura la base de datos
builder.Services.AddDbContext<AppDbContext>();

// Agrega las implementaciones de los repositorios al contenedor de inyecci�n de dependencias.
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

var app = builder.Build();

// Configura la canalizaci�n de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger para la documentaci�n de la API en entornos de desarrollo.
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirige las solicitudes HTTP a HTTPS si es necesario.
app.UseHttpsRedirection();

// Aplica autorizaci�n a las solicitudes.
app.UseAuthorization();

// Mapea las rutas de los controladores.
app.MapControllers();

// Ejecuta la aplicaci�n.
app.Run();
