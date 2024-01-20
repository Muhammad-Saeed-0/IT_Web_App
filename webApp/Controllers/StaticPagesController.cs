using Microsoft.AspNetCore.Mvc;

namespace webApp.Controllers
{
    public class StaticPagesController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult IT()
        {
            return View();
        }

        public IActionResult CS()
        {
            return View();
        }
        
        public IActionResult CareerOpportunities()
        {
            return View();
        }
    }
}
