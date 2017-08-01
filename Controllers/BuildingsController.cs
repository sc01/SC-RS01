using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sign.Models.Business;

namespace devin.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly RealStateDatabase _context;

        public BuildingsController(RealStateDatabase context)
        {
            _context = context;    
        }

        
        public async Task<IActionResult> Index()
        {
            var devinContext = _context.Buildings.Include(b => b.Customer);
            return View(await devinContext.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .Include(b => b.Customer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }

        
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(customer => customer.CustomerType.Contains("„‹‹«·‹‹ﬂ")), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Building building)
        {
            if (ModelState.IsValid)
            {
                _context.Add(building);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", building.CustomerId);
            return View(building);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings.SingleOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(customer => customer.CustomerType.Contains("„‹‹«·‹‹ﬂ")), "Id", "Name", building.CustomerId);
            return View(building);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] Building building)
        {
            if (id != building.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(building);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingExists(building.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", building.CustomerId);
            return View(building);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var building = await _context.Buildings
                .Include(b => b.Customer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (building == null)
            {
                return NotFound();
            }

            return View(building);
        }
        
        private bool BuildingExists(int id)
        {
            return _context.Buildings.Any(e => e.Id == id);
        }
    }
}
