using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Departamentos
    {

        [Required]
        [Key]
        public int idDepartamento { get; set; }

        [Required]
        public String NomeDepartamento { get; set; }

    }
}
