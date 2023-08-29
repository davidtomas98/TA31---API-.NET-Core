// Este archivo es generado automáticamente por Entity Framework para representar el estado actual del modelo de la base de datos.
// Contiene la información de cómo se debe construir el modelo en la base de datos.

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ex01.Data;

#nullable disable

namespace ex01.Migrations
{
    [DbContext(typeof(AppDbContext))] // Indica que este snapshot corresponde al contexto de AppDbContext.
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            // Configuración del modelo de la base de datos.

            // Se establece la versión del producto y la longitud máxima del identificador.
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            // Definición de la entidad Cliente en el modelo.
            modelBuilder.Entity("ex01.Models.Cliente", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Apellido")
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.Property<string>("Direccion")
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.Property<int?>("Dni")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<DateTime?>("Fecha")
                    .IsRequired()
                    .HasColumnType("datetime(6)");

                b.Property<string>("Nombre")
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.HasKey("Id");

                b.ToTable("Clientes"); // Define el nombre de la tabla en la base de datos.
            });
        }
    }
}
