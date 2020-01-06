using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class PaginationViewModel
    {



        public IEnumerable<Divisoes> Divisoes { get; set; }
        public IEnumerable<Cargos> Cargos { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FirstPageShow { get; set; }
        public int LastPageShow { get; set; }
        public IQueryable<Departamentos> Departamentos { get; internal set; }
    }
}

