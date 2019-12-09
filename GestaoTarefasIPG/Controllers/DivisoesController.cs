﻿using System;
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
        private readonly GestaoTarefasIPGContext _context;

        public DivisoesController(GestaoTarefasIPGContext context)
        {
            _context = context;
        }

        // GET: Divisoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Divisoes.ToListAsync());
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