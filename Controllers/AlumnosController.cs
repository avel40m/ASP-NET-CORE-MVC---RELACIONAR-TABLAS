using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using presonasimagen.Models;

namespace PresonasImagen.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment  _hostEnvironment;

        public AlumnosController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Alumnos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AlumnosModel.Include(a => a.Estudios).Include(a => a.Localidad).Include(a => a.Titulos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alumnos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosModel = await _context.AlumnosModel
                .Include(a => a.Estudios)
                .Include(a => a.Localidad)
                .Include(a => a.Titulos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnosModel == null)
            {
                return NotFound();
            }

            return View(alumnosModel);
        }

        // GET: Alumnos/Create
        public IActionResult Create()
        {
            ViewData["IdEstudio"] = new SelectList(_context.EstudiosModel, "Id", "Estudios");
            ViewData["IdLocalidad"] = new SelectList(_context.LocalidadModel, "Id", "Localidad");
            ViewData["IdTitulo"] = new SelectList(_context.TitulosModel, "Id", "Titulo");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Edad,ImageFile,IdLocalidad,IdEstudio,IdTitulo")] AlumnosModel alumnosModel)
        {
            if (ModelState.IsValid)
            {

                // GUARDAR IMAGEN
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(alumnosModel.ImageFile.FileName);
            string extension = Path.GetExtension(alumnosModel.ImageFile.FileName);
            alumnosModel.ImagenName=fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            using (var fileStream = new FileStream(path,FileMode.Create))
            {
                await alumnosModel.ImageFile.CopyToAsync(fileStream);
            }
                // Guardar datos
                _context.Add(alumnosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudio"] = new SelectList(_context.EstudiosModel, "Id", "Estudios", alumnosModel.IdEstudio);
            ViewData["IdLocalidad"] = new SelectList(_context.LocalidadModel, "Id", "Localidad", alumnosModel.IdLocalidad);
            ViewData["IdTitulo"] = new SelectList(_context.TitulosModel, "Id", "Titulo", alumnosModel.IdTitulo);
            return View(alumnosModel);
        }

        // GET: Alumnos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosModel = await _context.AlumnosModel.FindAsync(id);
            if (alumnosModel == null)
            {
                return NotFound();
            }
            ViewData["IdEstudio"] = new SelectList(_context.EstudiosModel, "Id", "Estudios", alumnosModel.IdEstudio);
            ViewData["IdLocalidad"] = new SelectList(_context.LocalidadModel, "Id", "Localidad", alumnosModel.IdLocalidad);
            ViewData["IdTitulo"] = new SelectList(_context.TitulosModel, "Id", "Titulo", alumnosModel.IdTitulo);
            return View(alumnosModel);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Edad,ImagenName,IdLocalidad,IdEstudio,IdTitulo")] AlumnosModel alumnosModel)
        {
            if (id != alumnosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnosModelExists(alumnosModel.Id))
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
            ViewData["IdEstudio"] = new SelectList(_context.EstudiosModel, "Id", "Id", alumnosModel.IdEstudio);
            ViewData["IdLocalidad"] = new SelectList(_context.LocalidadModel, "Id", "Id", alumnosModel.IdLocalidad);
            ViewData["IdTitulo"] = new SelectList(_context.TitulosModel, "Id", "Id", alumnosModel.IdTitulo);
            return View(alumnosModel);
        }

        // GET: Alumnos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosModel = await _context.AlumnosModel
                .Include(a => a.Estudios)
                .Include(a => a.Localidad)
                .Include(a => a.Titulos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnosModel == null)
            {
                return NotFound();
            }

            return View(alumnosModel);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnosModel = await _context.AlumnosModel.FindAsync(id);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath,"image",alumnosModel.ImagenName);
            
            if(System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _context.AlumnosModel.Remove(alumnosModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnosModelExists(int id)
        {
            return _context.AlumnosModel.Any(e => e.Id == id);
        }
    }
}
