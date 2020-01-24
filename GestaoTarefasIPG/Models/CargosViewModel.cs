using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class CargosViewModel
    {

        public IEnumerable<Cargos> Cargos { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FirstPageShow { get; set; }
        public int LastPageShow { get; set; }

        public string StringProcurar { get; set; }
        public string Procurar { get; set; }
        public string Sort { get; set; }
    }
}
