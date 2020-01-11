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
            PopulateCargos(db);
            PopulateDepartamentos(db);
            PopulateDivisao(db);
        }
        public static void PopulateCargos(GestaoTarefasIPGContext db)
        {
            if (db.Cargos.Any())
            {
                return;
            }
            db.Cargos.AddRange(
                new Cargos { NomeCargo = "Professor" }, 
                new Cargos { NomeCargo = "Funcionario" },
                new Cargos { NomeCargo = "Secretária" },
                new Cargos { NomeCargo = "Auxiliar" },
                new Cargos { NomeCargo = "Gestor" },
                new Cargos { NomeCargo = "Presidente" },
                new Cargos { NomeCargo = "Vice presidente" },
                new Cargos { NomeCargo = "" }

                );
            db.SaveChanges();


        }

        public static void PopulateDivisao(GestaoTarefasIPGContext db)
        {
            if (db.Divisoes.Any())
            {
                return;
            }
            db.Divisoes.AddRange(
                new Divisoes { NumDivisao = "42" },
                new Divisoes { NumDivisao = "43" },
                new Divisoes { NumDivisao = "44" },
                new Divisoes { NumDivisao = "45" },
                new Divisoes { NumDivisao = "49" }

                );
            db.SaveChanges();


        }

        public static void PopulateDepartamentos(GestaoTarefasIPGContext db)
        {
            if (db.Departamentos.Any())
            {
                return;
            }
            db.Departamentos.AddRange(
                new Departamentos { NomeDepartamento = "Gestão" },
                new Departamentos { NomeDepartamento = "Informática" },
                new Departamentos { NomeDepartamento = "Contabilidade" },
                new Departamentos { NomeDepartamento = "Civil" },
                new Departamentos { NomeDepartamento = "Marketing" },
                new Departamentos { NomeDepartamento = "Gestão de recursos humanos" },
                new Departamentos { NomeDepartamento = "Arrumos" },
                new Departamentos { NomeDepartamento = "Bar" },
                new Departamentos { NomeDepartamento = "Comunicações e relações publicas" },
                new Departamentos { NomeDepartamento = "Gabinetes" }


                );
            db.SaveChanges();


        }


    }
}

