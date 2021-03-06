﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Cargos
    {
        [Required]
        [Key]
        public int idCargo { get; set; }

        [Required(ErrorMessage = "Introduza um cargo válido!")]
        [StringLength(30)]
        public String NomeCargo { get; set; }

    }
}
