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

            return View(PopulateCheckBoxFilter());
        }



        public async Task<IActionResult> SearchDiseaseResults(string SearchPhrase)
        {
            if (SearchPhrase == null)
                return View("SearchDisease");


            return View("Index", await _context.Symptome.Where(Element => Element.SymptomInformation.Contains(SearchPhrase.ToLower())).ToListAsync());
        }

        public async Task<IActionResult> FilterDiseaseResults(string[] filter)
        {

            List<SelectListItem> items = PopulateCheckBoxFilter();
            List<Symptome> symptomes = _context.Symptome.ToList();
            foreach (SelectListItem item in items)
            {
                if (filter.Contains(item.Value))
                {
                    item.Selected = true;
                    foreach (Symptome symp in symptomes.ToList())
                    {
                        if (!symp.SymptomInformation.Contains(item.Text))
                            symptomes.Remove(symp);
                    }
                }

            }
          

            return View("Index", symptomes);
        }
        private List<SelectListItem> PopulateCheckBoxFilter()
        {

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (Filter filter in _context.Filter.ToArray())
            {
                items.Add(new SelectListItem
                {
                    Text = filter.Name.ToString(),
                    Value = filter.Id.ToString()

                });
            }
            return items;
        }
        private List<string> FindNonNull(string headache, string dizziness, string weakness, string stomach, string vomiting, string chest, string confusion)
        {
            List<string> NotNull = new List<string>();
            if (headache != null)
            {
                NotNull.Add(headache);
            }
            if (dizziness != null)
            {
                NotNull.Add(dizziness);
            }
            if (weakness != null)
            {
                NotNull.Add(weakness);
            }
            if (stomach != null)
            {
                NotNull.Add(stomach);
            }
            if (vomiting != null)
            {
                NotNull.Add(vomiting);
            }
            if (chest != null)
            {
                NotNull.Add(chest);
            }
            if (confusion != null)
            {
                NotNull.Add(confusion);

            }

            return NotNull;

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
