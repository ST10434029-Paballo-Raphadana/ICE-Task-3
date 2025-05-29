using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mango_ICE_Task_2.Data;
using Mango_ICE_Task_2.Models;

namespace Mango_ICE_Task_2.Controllers
{
    public class MangoController : Controller
    {
        private readonly MyDbContext _context;

        public MangoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Mango
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mangos.ToListAsync());
        }

        // GET: Mango/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mango = await _context.Mangos
                .FirstOrDefaultAsync(m => m.MangoId == id);
            if (mango == null)
            {
                return NotFound();
            }

            return View(mango);
        }

        // GET: Mango/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mango/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MangoId,MangoName")] Mango mango)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mango);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mango);
        }

        // GET: Mango/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mango = await _context.Mangos.FindAsync(id);
            if (mango == null)
            {
                return NotFound();
            }
            return View(mango);
        }

        // POST: Mango/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MangoId,MangoName")] Mango mango)
        {
            if (id != mango.MangoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mango);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MangoExists(mango.MangoId))
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
            return View(mango);
        }

        // GET: Mango/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mango = await _context.Mangos
                .FirstOrDefaultAsync(m => m.MangoId == id);
            if (mango == null)
            {
                return NotFound();
            }

            return View(mango);
        }

        // POST: Mango/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mango = await _context.Mangos.FindAsync(id);
            if (mango != null)
            {
                _context.Mangos.Remove(mango);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MangoExists(int id)
        {
            return _context.Mangos.Any(e => e.MangoId == id);
        }
    }
}
