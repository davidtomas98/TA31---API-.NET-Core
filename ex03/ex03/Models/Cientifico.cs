using System.ComponentModel.DataAnnotations;

namespace ex03.Models
{
    /// <summary>
    /// Represents a scientist and their associated projects.
    /// </summary>
    public class Cientifico
    {
        [Key]
        [StringLength(8)]
        public string Dni { get; set; }

        [StringLength(255)]
        public string NomApels { get; set; }

        // Navigation property for the projects assigned to this scientist
        public ICollection<Asignado_A> Asignados { get; set; }
    }
}
