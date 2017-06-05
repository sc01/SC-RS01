using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sign.Data;
using Sign.Models.Business;

namespace Sign.Controllers
{
    public class CostDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CostDaysController(ApplicationDbContext context)
        {
            _context = context;    
        }

       
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CostDay.Include(c => c.Bank);
            return View(await applicationDbContext.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costDay = await _context.CostDay
                .Include(c => c.Bank)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (costDay == null)
            {
                return NotFound();
            }

            return View(costDay);
        }

       
        public IActionResult Create()
        {
            ViewData["BankId"] = new SelectList(_context.Set<Bank>(), "Id", "Id");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] CostDay costDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costDay);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BankId"] = new SelectList(_context.Set<Bank>(), "Id", "Id", costDay.BankId);
            return View(costDay);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costDay = await _context.CostDay.SingleOrDefaultAsync(m => m.Id == id);
            if (costDay == null)
            {
                return NotFound();
            }
            ViewData["BankId"] = new SelectList(_context.Set<Bank>(), "Id", "Id", costDay.BankId);
            return View(costDay);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind] CostDay costDay)
        {
            if (id != costDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostDayExists(costDay.Id))
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
            ViewData["BankId"] = new SelectList(_context.Set<Bank>(), "Id", "Id", costDay.BankId);
            return View(costDay);
        }

     
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costDay = await _context.CostDay
                .Include(c => c.Bank)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (costDay == null)
            {
                return NotFound();
            }

            return View(costDay);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costDay = await _context.CostDay.SingleOrDefaultAsync(m => m.Id == id);
            _context.CostDay.Remove(costDay);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CostDayExists(int id)
        {
            return _context.CostDay.Any(e => e.Id == id);
        }
    }
}
