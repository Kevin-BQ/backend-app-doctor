using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class HistoriaClinica
    {
        //  Guid (Globally Unique Identifier) se utiliza para representar identificadores únicos = 123e4567-e89b-12d3-a456-426614174000
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Paciente Requerido")]
        public int PacienteId { get; set; }

        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
