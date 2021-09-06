using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using presonasimagen.Models;

namespace PresonasImagen.Controllers
{
    public class EstudiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estudios
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstudiosModel.ToListAsync());
        }


        // GET: Estudios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Estudios")] EstudiosModel estudiosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudiosModel);
        }

        // GET: Estudios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiosModel = await _context.EstudiosModel.FindAsync(id);
            if (estudiosModel == null)
            {
                return NotFound();
            }
            return View(estudiosModel);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Estudios")] EstudiosModel estudiosModel)
        {
            if (id != estudiosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudiosModelExists(estudiosModel.Id))
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
            return View(estudiosModel);
        }

        // GET: Estudios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiosModel = await _context.EstudiosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiosModel == null)
            {
                return NotFound();
            }

            return View(estudiosModel);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiosModel = await _context.EstudiosModel.FindAsync(id);
            _context.EstudiosModel.Remove(estudiosModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudiosModelExists(int id)
        {
            return _context.EstudiosModel.Any(e => e.Id == id);
        }
    }
}
