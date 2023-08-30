using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio1.Models
{
    // Clase que define la entidad Cliente en el modelo.
    public class Cliente
    {
        [Required]
        [Key] // Indica que esta propiedad es la clave primaria.
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que esta propiedad es generada automáticamente.
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string? Apellido { get; set; }

        [Required]
        [StringLength(250)]
        public string? Direccion { get; set; }

        [Required]
        public int? Dni { get; set; }

        [Required]
        public DateTime? Fecha { get; set; }
    }
}
