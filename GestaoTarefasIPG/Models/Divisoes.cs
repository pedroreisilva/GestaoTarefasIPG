using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GestaoTarefasIPG.Models
{
    public class Divisoes
    {
        [Key]
        public int IdDivisao { get; set; }
        [Required]
        public String NumDivisao { get; set; }
    }
}
