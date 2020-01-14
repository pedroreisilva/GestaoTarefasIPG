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
    public class DivisoesController : Controller
    {
        private int NUMBER_PAGES_BEFORE_AND_AFTER = 8;
        private int NUMBER_FUNC_PER_PAGE = 8;
        private int FUNC_PER_PAGE = 8;

        private readonly GestaoTarefasIPGContext _context;

        public DivisoesController(GestaoTarefasIPGContext context)
        {
            _context = context;
        }

        // GET: Divisoe
        public async Task<IActionResult> Index(int page = 1, string searchString = "", string sort = "true", string procurar = "Nome")
        {

            var Divisoes = from p in _context.Divisoes
                                select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                Divisoes = Divisoes.Where(p => p.NumDivisao.Contains(searchString));
                if (procurar.Equals("Nome"))
                {
                    Divisoes = Divisoes.Where(p => p.NumDivisao.Contains(searchString));
                }
            }






            decimal numberDivisoes = _context.Divisoes.Count();
            PaginationViewModel vm = new PaginationViewModel{

                Sort = sort,
                Divisoes = _context.Divisoes.OrderBy(p => p.NumDivisao).Skip((page - 1)* FUNC_PER_PAGE).Take(FUNC_PER_PAGE),
                CurrentPage = page,
                FirstPageShow = Math.Max(1,page - NUMBER_PAGES_BEFORE_AND_AFTER),
                TotalPages = (int)Math.Ceiling(numberDivisoes / NUMBER_FUNC_PER_PAGE),
                Procurar = procurar

            };


            if (sort.Equals("true"))
            {
                vm.Divisoes = Divisoes.OrderBy(p => p.NumDivisao).Skip((page - 1) * NUMBER_FUNC_PER_PAGE).Take(NUMBER_FUNC_PER_PAGE);
            }
            else
            {
                vm.Divisoes = Divisoes.OrderByDescending(p => p.NumDivisao).Skip((page - 1) * NUMBER_FUNC_PER_PAGE).Take(NUMBER_FUNC_PER_PAGE);
            }










            vm.LastPageShow = Math.Min(vm.TotalPages, page + NUMBER_PAGES_BEFORE_AND_AFTER);
            vm.StringProcurar = searchString;

            return View(vm);
        }









        // GET: Divisoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisoes = await _context.Divisoes
                .FirstOrDefaultAsync(m => m.idDivisao == id);
            if (divisoes == null)
            {
                return NotFound();
            }

            return View(divisoes);
        }

        // GET: Divisoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divisoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDivisao,NumDivisao")] Divisoes divisoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divisoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divisoes);
        }

        // GET: Divisoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisoes = await _context.Divisoes.FindAsync(id);
            if (divisoes == null)
            {
                return NotFound();
            }
            return View(divisoes);
        }

        // POST: Divisoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDivisao,NumDivisao")] Divisoes divisoes)
        {
            if (id != divisoes.idDivisao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divisoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisoesExists(divisoes.idDivisao))
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
            return View(divisoes);
        }

        // GET: Divisoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divisoes = await _context.Divisoes
                .FirstOrDefaultAsync(m => m.idDivisao == id);
            if (divisoes == null)
            {
                return NotFound();
            }

            return View(divisoes);
        }

        // POST: Divisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divisoes = await _context.Divisoes.FindAsync(id);
            _context.Divisoes.Remove(divisoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisoesExists(int id)
        {
            return _context.Divisoes.Any(e => e.idDivisao == id);
        }
    }
}
