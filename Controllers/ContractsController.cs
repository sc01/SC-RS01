using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sign.Models.Business;


namespace Sign.Controllers
{
    public class ContractsController : Controller
    {
        private readonly RealStateDatabase _context;

        public ContractsController(RealStateDatabase context)
        {
            _context = context;    
        }

       
        public async Task<IActionResult> Index()
        {
            var database = _context.Contracts.Include(c => c.Customer);
            return View(await database.ToListAsync());
        }

       
   
      
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers.Where(customer => customer.CustomerType.Contains("مـسـتـأجـر")), "Id", "Name");
            ViewBag.builingData = _context.Buildings.Include(building => building.Apartments).ToList();
            return View(new Contract());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Contract contract)
        {
            if (ModelState.IsValid)
            {
                if (contract.ApartId < 0)
                {
                    contract.BuldId = contract.ApartId * -1;
                    
                }
                _context.Add(contract);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
            return View(contract);
        }

        
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewBag.builingData = _context.Buildings.Include(building => building.Apartments).ToList();

            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", contract.CustomerId);
            return View(contract);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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

            ViewBag.builingData = _context.Buildings.Include(building => building.Apartments).ToList();

            ViewData["CustomerId"] = new SelectList(_context.Customers, "id", "id", contract.CustomerId);
            return View(contract);
        }

        public bool Delete(long id)
        {
            var contract = _context.Contracts.SingleOrDefault(m => m.Id == id);
            if (contract != null) _context.Contracts.Remove(contract);
            _context.SaveChanges();
            return true;
        }

        private bool ContractExists(long id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
