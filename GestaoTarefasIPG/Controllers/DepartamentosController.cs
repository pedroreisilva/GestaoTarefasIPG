using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Controllers
{
    public class DepartamentosController : Controller
    {

        private int NUMBER_PAGES_BEFORE_AND_AFTER = 8;
        private int NUMBER_FUNC_PER_PAGE = 8;
        private int FUNC_PER_PAGE = 8;

        private readonly GestaoTarefasIPGContext _context;

        public DepartamentosController(GestaoTarefasIPGContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index(int page = 1, string searchString = "", string sort = "true", string procurar = "Nome")
        {


            var departamentos = from p in _context.Departamentos
            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                departamentos = departamentos.Where(p => p.NomeDepartamento.Contains(searchString));
                if (procurar.Equals("Nome"))
                {
                    departamentos = departamentos.Where(p => p.NomeDepartamento.Contains(searchString));
                }
            }

            decimal numberDepartamentos = _context.Departamentos.Count();
            DepartamentosViewModel vm = new DepartamentosViewModel{
                Sort = sort,
                Departamentos = _context.Departamentos.OrderBy(p => p.NomeDepartamento).Skip((page - 1) * FUNC_PER_PAGE).Take(FUNC_PER_PAGE),
                CurrentPage = page,
                FirstPageShow = Math.Max(1, page - NUMBER_PAGES_BEFORE_AND_AFTER),
                TotalPages = (int)Math.Ceiling(numberDepartamentos / NUMBER_FUNC_PER_PAGE),
                Procurar = procurar
            };
            if (sort.Equals("true"))
            {
                vm.Departamentos = departamentos.OrderBy(p => p.NomeDepartamento).Skip((page - 1) * NUMBER_FUNC_PER_PAGE).Take(NUMBER_FUNC_PER_PAGE);
            }
            else
            {
                vm.Departamentos = departamentos.OrderByDescending(p => p.NomeDepartamento).Skip((page - 1) * NUMBER_FUNC_PER_PAGE).Take(NUMBER_FUNC_PER_PAGE);
            }


            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_PAGES_BEFORE_AND_AFTER);
            vm.StringProcurar = searchString;


            return View(vm);
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.idDepartamento == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDepartamento,NomeDepartamento")] Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departamentos);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return View("Sucesso");
            }
            return View(departamentos);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.Departamentos.FindAsync(id);
            if (departamentos == null)
            {
                return NotFound();
            }
            return View(departamentos);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDepartamento,NomeDepartamento")] Departamentos departamentos)
        {
            if (id != departamentos.idDepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentosExists(departamentos.idDepartamento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return View("Sucesso");
            }
            return View(departamentos);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamentos = await _context.Departamentos
                .FirstOrDefaultAsync(m => m.idDepartamento == id);
            if (departamentos == null)
            {
                return NotFound();
            }

            return View(departamentos);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departamentos = await _context.Departamentos.FindAsync(id);
            _context.Departamentos.Remove(departamentos);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return View("Sucesso");
        }

        private bool DepartamentosExists(int id)
        {
            return _context.Departamentos.Any(e => e.idDepartamento == id);
        }
    }
}