﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ejercicio2.Models
{
    // Entidad que representa a un cliente en la base de datos.
    public class Cliente
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        // Colección de videos asociados a este cliente.
        public ICollection<Video>? Videos { get; set; }
    }
}
