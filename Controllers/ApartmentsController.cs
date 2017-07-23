using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sign.HelperClasses;
using Sign.Models.Business;

namespace Sign.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly RealStateDatabase _context;

        readonly FilesHelper _filesHelper;

        String serverMapPath = "/Files/somefiles/";

        private string UrlBase = "/Files/somefiles/";

        String DeleteURL = "/Apartments/DeleteFile/?file=";

        String DeleteType = "GET";

        public ApartmentsController(RealStateDatabase context , IHostingEnvironment hostenvirment)
        {
            _context = context;
            string rootpath = hostenvirment.WebRootPath + @"\Files\somefiles\";
            _filesHelper = new FilesHelper(DeleteURL, DeleteType, rootpath, UrlBase, serverMapPath);
        }


        [HttpPost]
        public JsonResult Upload()
        {
            var resultList = new List<ViewDataUploadFilesResult>();

            _filesHelper.UploadWholeFile(Request, resultList);

            JsonFiles files = new JsonFiles(resultList);

            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error ");
            }

            //here save image file name by extions to retrive it other time
            return Json(files);
        }

        public JsonResult GetFileList(int id)
        {
          var data =  _context.Apartments.Include(apartment => apartment.AttachmentForApartments)
                .SingleOrDefault(apartment => apartment.Id == id);
            List<string> list = new List<string>();

            foreach (AttachmentForApartment apartment in data.AttachmentForApartments)
            {
                list.Add(apartment.Name);
            }

            return Json(_filesHelper.GetFileList(list));
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartments.ToListAsync());
        }

      
        public IActionResult Create()
        {
           
            ViewBag.aprtmentData = new SelectList(_context.Customers.Where(customer => customer.CustomerType.Contains("„‹‹«·‹‹ﬂ")) , "Id" , "Name");
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
           
            var Apartments = await _context.Apartments.Include(apartment => apartment.Customer).SingleOrDefaultAsync(m => m.Id == id);

            ViewBag.aprtmentData = new SelectList(_context.Customers.Where(customer => customer.CustomerType.Contains("„‹‹«·‹‹ﬂ")), "Id", "Name", Apartments.CustomerId);

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
                    throw;
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

        [HttpGet]
        public async Task<JsonResult> DeleteFile(string file)
        {
            IEnumerable<AttachmentForApartment> filetodelete =  _context.AttachmentForApartments.Where(apartment => apartment.Name == file);
            _context.RemoveRange(filetodelete);
            await _context.SaveChangesAsync();
            _filesHelper.DeleteFile(file);
            return Json("OK");
        }
    }
}
