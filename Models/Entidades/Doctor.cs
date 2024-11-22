using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Apellidos Requeridos")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Apellidos debe ser Minimo 1 Maximo 60 caracteres")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "Nombres Requeridos")]
        [StringLength(60, MinimumLength =1, ErrorMessage ="Nombre debe ser Minimo 1 Maximo 60 caracteres")]
        public string Nombres { get; set; }


        [Required(ErrorMessage = "Direccion Requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Direccion debe ser Minimo 1 Maximo 100 caracteres")]
        public string Direccion { get; set; }


        [StringLength(40, MinimumLength = 1, ErrorMessage = "Telefono debe ser Minimo 1 Maximo 40 caracteres")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "Genero Requerido")]
        public char Genero { get; set; }


        [Required(ErrorMessage = "Especialida Requerida")]
        public int EspecialidaId { get; set; }


        [ForeignKey("EspecialidaId")]
        public Especialidad Especialidad { get; set; }


        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

    }
}
