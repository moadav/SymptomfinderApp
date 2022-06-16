using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Symptomfinder.Data;
using Symptomfinder.Models;

namespace Symptomfinder.Controllers
{
    public class SymptomesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SymptomesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Symptomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Symptome.ToListAsync());
        }

        public IActionResult SearchDisease()
        {      
            return View();
        }



        public async Task<IActionResult> SearchDiseaseResults(string SearchPhrase)
        {
            return View("Index", await _context.Symptome.Where(s => s.Name.Contains(SearchPhrase) || s.Symptoms.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Symptomes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptome = await _context.Symptome
                .FirstOrDefaultAsync(m => m.Id == id);
            if (symptome == null)
            {
                return NotFound();
            }

            return View(symptome);
        }

        // GET: Symptomes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Symptomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Symptoms,Causes,Treatment")] Symptome symptome)
        {
            if (ModelState.IsValid)
            {
                _context.Add(symptome);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(symptome);
        }

        // GET: Symptomes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptome = await _context.Symptome.FindAsync(id);
            if (symptome == null)
            {
                return NotFound();
            }
            return View(symptome);
        }

        // POST: Symptomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Symptoms,Causes,Treatment")] Symptome symptome)
        {
            if (id != symptome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(symptome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SymptomeExists(symptome.Id))
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
            return View(symptome);
        }

        // GET: Symptomes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var symptome = await _context.Symptome
                .FirstOrDefaultAsync(m => m.Id == id);
            if (symptome == null)
            {
                return NotFound();
            }

            return View(symptome);
        }

        // POST: Symptomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var symptome = await _context.Symptome.FindAsync(id);
            _context.Symptome.Remove(symptome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SymptomeExists(int id)
        {
            return _context.Symptome.Any(e => e.Id == id);
        }
    }
}
