using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SeedData
    {
        public static void Populate(GestaoTarefasIPGContext db)
        {
            if (db.Cargos.Any())
            {
                return;
            }
            db.Cargos.AddRange(
                new Cargos { NomeCargo = "Professor" }, 
                new Cargos { NomeCargo = "Funcionario" },
                new Cargos { NomeCargo = "Secretária" },
                new Cargos { NomeCargo = "Auxiliar" }

                );
            db.SaveChanges();
        }
    }
}

