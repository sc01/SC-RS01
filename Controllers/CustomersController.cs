using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sign.Models.Business;

namespace Sign.Controllers
{
    public class CustomersController : Controller
    {
        private readonly RealStateDatabase _context;
        private IHostingEnvironment _env;

        public CustomersController(RealStateDatabase context , IHostingEnvironment env)
        {
            _env = env;
            _context = context;    
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["Conterydata"] = ContreyList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

     
        public async Task<IActionResult> Edit(long? id)
        {
            ViewData["Conterydata"] = ContreyList();
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        public bool Delete(long id)
        {
            var customers=  _context.Customers.SingleOrDefault(m => m.Id == id);
            _context.Customers.Remove(customers);
             _context.SaveChanges();
            return true;
        }

        SelectList ContreyList()
        {
            List<string> allContery=new List<string>();
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(_env.WebRootPath + "/Contery.txt");
            while ((line = file.ReadLine()) != null)
            {
                allContery.Add(line);
            }

            file.Close();
            return new SelectList(allContery);
        }
    }
}
