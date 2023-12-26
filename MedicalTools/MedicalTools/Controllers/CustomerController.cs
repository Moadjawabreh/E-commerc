using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalTools.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationContext _db;
        public CustomerController(ApplicationContext db)
        {
            _db = db;
        }
        public class cartProductTuples
        {
            public Cart Cart { get; set; }
            public Product Product { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Products()
        {
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }
        public IActionResult Cart()
        {
            
            int id = 1;
            var cartProductTuples = _db.cart
                .Where(u => u.UserId == id)
                .Select(cart => new cartProductTuples
                {
                     Cart = cart,
                     Product = _db.products.FirstOrDefault(p => p.ID == cart.productId)
                }).ToList();

            return View(cartProductTuples);
        }
        public IActionResult Checkout()
        {
            int id = 1;
            var cartProductTuples = _db.cart
                .Where(u => u.UserId == id)
                .Select(cart => new cartProductTuples
                {
                    Cart = cart,
                    Product = _db.products.FirstOrDefault(p => p.ID == cart.productId)
                }).ToList();

            return View(cartProductTuples);
        }

        public IActionResult Payment()
        {
            TempData["success"] = "Payment processed successfully";
            TempData["error"] = "Payment does't work";
            return RedirectToAction("Index");
        }

		public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }






    }
}
