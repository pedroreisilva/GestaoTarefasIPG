using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefasIPG.Models
{
    public class DivisoesContext : DbContext
    {
        public DivisoesContext (DbContextOptions<DivisoesContext> options)
            : base(options)
        {
        }

        public DbSet<GestaoTarefasIPG.Models.Divisoes> Divisoes { get; set; }
    }
}
