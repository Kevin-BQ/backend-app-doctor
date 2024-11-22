﻿using Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Apellidos Requeridos")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Apellidos debe ser Minimo 1 Maximo 60 caracteres")]
        public string Apellidos { get; set; }


        [Required(ErrorMessage = "Nombres Requeridos")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Nombre debe ser Minimo 1 Maximo 60 caracteres")]
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

        public string NombreEspecialidad { get; set; }

        public int Estado { get; set; }
    }
}
