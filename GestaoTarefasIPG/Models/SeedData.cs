using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SeedData
    {

        private const string ADMIN = "admin";
        private const string MANAGER = "manager";
        private const string FUNCIONARIO = "funcionario";

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
                new Cargos { NomeCargo = "Auxiliar" }

                );
            db.SaveChanges();


        }

        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_ID = "admin@ipg.pt";
            const string ADMIN_PW = "asd123";

            const string MANAGER_ID = " manager@ipg.pt";
            const string MANAGER_PW = "asd123";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_ID);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = ADMIN_ID,
                    Email = ADMIN_ID
                };

                await userManager.CreateAsync(user, ADMIN_PW);
            }

            if (!await userManager.IsInRoleAsync(user, ADMIN))
            {
                await userManager.AddToRoleAsync(user, ADMIN);
            }

            user = await userManager.FindByNameAsync(MANAGER_ID);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = MANAGER_ID,
                    Email = MANAGER_ID
                };

                await userManager.CreateAsync(user, MANAGER_PW);

            }

            if (!await userManager.IsInRoleAsync(user, MANAGER))
            {
                await userManager.AddToRoleAsync(user, MANAGER);
            }

            user = await userManager.FindByNameAsync("teste1@ipg.pt");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "teste1@ipg.pt",
                    Email = "teste1@ipg.pt"
                };
                await userManager.CreateAsync(user, ADMIN_PW);
            }


            user = await userManager.FindByNameAsync("teste2@ipg.pt");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "teste2@ipg.pt",
                    Email = "teste2@ipg.pt"
                };
                await userManager.CreateAsync(user, ADMIN_PW);

            }
        }

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if(!await roleManager.RoleExistsAsync(ADMIN))
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN));
            }

            if(!await roleManager.RoleExistsAsync(MANAGER))
            {
                await roleManager.CreateAsync(new IdentityRole(MANAGER));
            }

            if (!await roleManager.RoleExistsAsync(FUNCIONARIO))
            {
                await roleManager.CreateAsync(new IdentityRole(MANAGER));

            }
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
                new Departamentos { NomeDepartamento = "Marketing" }

                );
            db.SaveChanges();


        }


    }
}

