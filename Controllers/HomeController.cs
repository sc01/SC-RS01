using Microsoft.AspNetCore.Mvc;
using Sign.Models.Business;

namespace SC_RS01.Controllers
{
    public class HomeController : Controller
    {
        private RealStateDatabase _db;
        public HomeController(RealStateDatabase db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}