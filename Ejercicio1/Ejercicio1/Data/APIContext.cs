using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Storage;


namespace Ejercicio1.Data
{
    // Clase que define el contexto de la base de datos de la aplicación.
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        // Constructor que recibe las opciones de configuración y la configuración de la aplicación.
        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // Define un DbSet para la entidad Cliente, lo que permite interactuar con la tabla de clientes en la base de datos.
        public DbSet<Cliente> Clientes { get; set; }

        // Método llamado al configurar la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Obtiene la cadena de conexión desde la configuración de la aplicación.
            var connectionString = configuration.GetConnectionString("MySqlConnection");

            // Define la versión del servidor MySQL que se va a utilizar.
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            // Configura el contexto para usar MySQL con la cadena de conexión y la versión del servidor especificadas.
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
