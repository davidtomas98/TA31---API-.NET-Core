using System.ComponentModel.DataAnnotations;

namespace Ejercicio3.Models
{
    /// <summary>
    /// Represents a project and its assigned scientists.
    /// </summary>
    public class Proyecto
    {
        [Key]
        [StringLength(4)]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public int Horas { get; set; }

        // Navigation property for the scientists assigned to this project
        public ICollection<Asignado_A> Asignados { get; set; }
    }
}
