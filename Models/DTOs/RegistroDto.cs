﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class RegistroDto
    {
        [Required(ErrorMessage = "UserName Requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Requerido")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El password deber der Minimo 3 Maximo 10 caracteres")]
        public string Password{ get; set; }
    }
}