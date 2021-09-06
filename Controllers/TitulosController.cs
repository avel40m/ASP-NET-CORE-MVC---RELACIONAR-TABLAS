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
    public class TitulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TitulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Titulos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TitulosModel.OrderBy(t => t.Titulo).ToListAsync());
        }


        // GET: Titulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo")] TitulosModel titulosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titulosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(titulosModel);
        }

        // GET: Titulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulosModel = await _context.TitulosModel.FindAsync(id);
            if (titulosModel == null)
            {
                return NotFound();
            }
            return View(titulosModel);
        }

        // POST: Titulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo")] TitulosModel titulosModel)
        {
            if (id != titulosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titulosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitulosModelExists(titulosModel.Id))
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
            return View(titulosModel);
        }

        // GET: Titulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titulosModel = await _context.TitulosModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (titulosModel == null)
            {
                return NotFound();
            }

            return View(titulosModel);
        }

        // POST: Titulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titulosModel = await _context.TitulosModel.FindAsync(id);
            _context.TitulosModel.Remove(titulosModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitulosModelExists(int id)
        {
            return _context.TitulosModel.Any(e => e.Id == id);
        }
    }
}
