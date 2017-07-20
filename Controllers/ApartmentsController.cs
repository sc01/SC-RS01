using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sign.Models.Business;

namespace Sign.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly RealStateDatabase _context;

        public ApartmentsController(RealStateDatabase context)
        {
            _context = context;    
        }

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartments.ToListAsync());
        }

      
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Apartments = await _context.Apartments
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Apartments == null)
            {
                return NotFound();
            }

            return View(Apartments);
        }

       
        public IActionResult Create()
        {
            return View(new Apartment());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Apartment apartments)
        {
            if (ModelState.IsValid)
            {
                apartments.EntryDate = DateTime.Now.Date;
                _context.Add(apartments);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apartments);
        }

        
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Apartments = await _context.Apartments.SingleOrDefaultAsync(m => m.Id == id);
            if (Apartments == null)
            {
                return NotFound();
            }
            return View(Apartments);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] Apartment apartments)
        {
            if (id != apartments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentsExists(apartments.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(apartments);
        }
        
        public bool Delete(long id)
        {
            var apartments =  _context.Apartments.SingleOrDefault(m => m.Id == id);
            _context.Apartments.Remove(apartments);
             _context.SaveChanges();
            return true;
        }

        private bool ApartmentsExists(long id)
        {
            return _context.Apartments.Any(e => e.Id == id);
        }
    }
}
