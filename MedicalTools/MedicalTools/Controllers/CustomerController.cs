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
		public class cartProductOrderTuples
		{
			public Cart Cart { get; set; }
			public Product Product { get; set; }
            public Order Order { get; set; }
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
            
            int id = 1; // id for current user must fill from session 
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
            int id = 1; // id for current user must fill from session 
            var cartProductTuples = _db.cart
                .Where(u => u.UserId == id)
                .Select(cart => new cartProductTuples
                {
                    Cart = cart,
                    Product = _db.products.FirstOrDefault(p => p.ID == cart.productId)
                }).ToList();

            Order obj = new Order();
            double totalPrice = 0;
            foreach (var price in cartProductTuples)
            {
                totalPrice += price.Cart.Quantity * price.Product.Price;
            }
            obj.Total = totalPrice;

            return View(obj);
        }
        [HttpPost]
        public IActionResult Checkout(Order ord)
        {
            var obj = _db.payments;
            foreach (var item in obj)
            {
                if (item.cardNo == ord.card)

                {
                        if (item.Password == ord.password)
                    {
                        _db.orders.Add(ord);
                        _db.SaveChanges();
                        int id = 1; // id for current user must fill from session 
                        var cartsToDelete = _db.cart.Where(cart => cart.UserId == id);

                        _db.cart.RemoveRange(cartsToDelete);
                        _db.SaveChanges();

                        TempData["success"] = "Payment processed successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Payment does't work";
                        return View();
                    }
                }
                else
                {
                    TempData["error"] = "Payment does't work";
                    return View();
                }
            }
            TempData["error"] = "Payment does't work";
            return View();
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
