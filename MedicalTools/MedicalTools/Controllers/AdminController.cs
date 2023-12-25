using Microsoft.AspNetCore.Mvc;

namespace MedicalTools.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
