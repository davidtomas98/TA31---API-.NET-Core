using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ex02.Models
{
    // Entidad que representa un video en la base de datos.
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string? Title { get; set; }

        [Required]
        [StringLength(250)]
        public string? Director { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int CliId { get; set; }

        // Propiedad de navegación para acceder al cliente asociado a este video.
        public Cliente? Cliente { get; set; }
    }
}
