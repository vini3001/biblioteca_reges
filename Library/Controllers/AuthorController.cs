using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Authorize(Roles = "User")]
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);
            if(authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author authors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(authors);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FindAsync(id);
            if(authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Author authors)
        {
            if (id != authors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorsExists(authors.Id))
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
            return View(authors);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entidade 'ApplicationDbContext.Authors' não encontrada!");
            };

            var authors = await _context.Authors.FindAsync(id);
            if (authors != null)
            {
                _context.Authors.Remove(authors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorsExists(int? id)
        {
            return _context.Authors.Any(e => e.Id == id);
        }
    }
}
