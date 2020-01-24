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
    public class CargosController : Controller
    {

        private int NUMBER_PAGES_BEFORE_AND_AFTER = 8;
        private int NUMBER_CARGO_PER_PAGE = 8;
        private int CARGOS_PER_PAGE = 8;

        private readonly GestaoTarefasIPGContext _context;

        public CargosController(GestaoTarefasIPGContext context)
        {
            _context = context;
        }

        // GET: Cargos
        public async Task<IActionResult> Index(int page = 1, string searchString = "", string sort = "true", string procurar = "Nome")
        {


            var cargos = from p in _context.Cargos
                                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                cargos = cargos.Where(p => p.NomeCargo.Contains(searchString));
                if (procurar.Equals("Nome"))
                {
                    cargos = cargos.Where(p => p.NomeCargo.Contains(searchString));
                }
            }

            decimal numberCargos = _context.Cargos.Count();
            CargosViewModel vm = new CargosViewModel
            {


                Sort = sort,
                Cargos = _context.Cargos.OrderBy(p => p.NomeCargo).Skip((page - 1) * CARGOS_PER_PAGE).Take(CARGOS_PER_PAGE),
                CurrentPage = page,
                FirstPageShow = Math.Max(1, page - NUMBER_PAGES_BEFORE_AND_AFTER),
                TotalPages = (int)Math.Ceiling(numberCargos / NUMBER_CARGO_PER_PAGE),
                Procurar = procurar
            };
            if (sort.Equals("true"))
            {
                vm.Cargos = cargos.OrderBy(p => p.NomeCargo).Skip((page - 1) * NUMBER_CARGO_PER_PAGE).Take(NUMBER_CARGO_PER_PAGE);
            }
            else
            {
                vm.Cargos = cargos.OrderByDescending(p => p.NomeCargo).Skip((page - 1) * NUMBER_CARGO_PER_PAGE).Take(NUMBER_CARGO_PER_PAGE);
            }


            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_PAGES_BEFORE_AND_AFTER);
            vm.StringProcurar = searchString;


            return View(vm);
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _context.Cargos
                .FirstOrDefaultAsync(m => m.idCargo == id);
            if (cargos == null)
            {
                return NotFound();
            }

            return View(cargos);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCargo,NomeCargo")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargos);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _context.Cargos.FindAsync(id);
            if (cargos == null)
            {
                return NotFound();
            }
            return View(cargos);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCargo,NomeCargo")] Cargos cargos)
        {
            if (id != cargos.idCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargosExists(cargos.idCargo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cargos);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _context.Cargos
                .FirstOrDefaultAsync(m => m.idCargo == id);
            if (cargos == null)
            {
                return NotFound();
            }

            return View(cargos);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);
            _context.Cargos.Remove(cargos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargosExists(int id)
        {
            return _context.Cargos.Any(e => e.idCargo == id);
        }
    }
}
