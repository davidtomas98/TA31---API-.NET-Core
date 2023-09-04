using Ejercicio2.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio2.Data
{
    // Contexto de base de datos para la aplicación.
    public class APIContext : DbContext
    {
        private readonly IConfiguration configuration;

        public APIContext(DbContextOptions<APIContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        // Conjuntos de entidades en la base de datos.
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Video> Videos { get; set; }

        // Configuración de relaciones y restricciones.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Videos)
                .HasForeignKey(v => v.CliId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        // Configuración de la conexión a la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");
            var serverVersion = new MySqlServerVersion(new Version(10, 11, 2));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
