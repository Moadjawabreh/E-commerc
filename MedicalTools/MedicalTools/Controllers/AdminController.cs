using Microsoft.AspNetCore.Mvc;

namespace MedicalTools.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Testimonials() 
        {
            return View();
        }


    }
}
