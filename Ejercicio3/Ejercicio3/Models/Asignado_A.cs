using System.ComponentModel.DataAnnotations;

namespace Ejercicio3.Models
{
    /// <summary>
    /// Represents the relationship between a scientist and a project.
    /// </summary>
    public class Asignado_A
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string CientificoDni { get; set; }

        [Required]
        [StringLength(4)]
        public string ProyectoId { get; set; }

        // Navigation property for the associated scientist (Cientifico)
        public Cientifico Cientifico { get; set; }

        // Navigation property for the associated project (Proyecto)
        public Proyecto Proyecto { get; set; }
    }
}
