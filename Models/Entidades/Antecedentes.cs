﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Antecedentes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Historial Clinico Requerido")]
        public Guid HistoriaClinicaId { get; set; }

        [ForeignKey("HistoriaClinicaId")]
        public HistoriaClinica HistoriaClinica { get; set; }

        [Required(ErrorMessage = "Observacion Requerida")]
        [StringLength(300, MinimumLength = 1, ErrorMessage = "Observacion debe ser Minimo 1 Maximo 300 caracteres")]
        public string Observacion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
