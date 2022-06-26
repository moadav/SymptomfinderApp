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
            return View("Index", await _context.Symptome.Where(Element => Element.Name.Contains(SearchPhrase.ToLower()) || Element.SymptomInformation.Contains(SearchPhrase.ToLower())).ToListAsync());
        }
        public async Task<IActionResult> FilterDiseaseResults(string Choice)
        {
            return View("Index", await _context.Symptome.Where(Element => Element.Name.Contains(Choice.ToLower()) || Element.SymptomInformation.Contains(Choice.ToLower())).ToListAsync());
        }
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
    }
}
