using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class EspecialidaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es Requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Debe contener Minimo 1 Maximo 60 caracteres")]
        public string NombreEspecialidad { get; set; }

        [Required(ErrorMessage = "La descripcion es Requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Debe contener Minimo 1 Maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es Requerido")]
        public int Estado { get; set; } // 1 - 0
    }
}
