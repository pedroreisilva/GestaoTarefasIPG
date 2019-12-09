using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Models
{
    public class GestaoTarefasIPGContext : DbContext
    {
        public GestaoTarefasIPGContext (DbContextOptions<GestaoTarefasIPGContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefasIPG.Models.Cargos> Cargos { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Divisoes> Divisoes { get; set; }

        public DbSet<GestaoTarefasIPG.Models.Departamentos> Departamentos { get; set; }
    }
}
