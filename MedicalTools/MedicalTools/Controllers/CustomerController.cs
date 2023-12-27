using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;

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


        public IActionResult Products( int id )
        {
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }
        public IActionResult Cart()
        {

            // id for current user must fill from session
            string? userJson = HttpContext.Session.GetString("LiveUSer");
            var user = JsonConvert.DeserializeObject<User>(userJson);
            if (true)
            {
				var products = _db.cart.Include(p=>p.product)
				.Where(u => u.UserId == user.ID).ToList();

				return View(products);
			}

			//var cartsWithId = _db.cart
            //.Where(u => u.UserId == user.ID).ToList();


			return RedirectToAction("Index","Login");
        }
        public IActionResult Checkout()
        {
            string? userJson = HttpContext.Session.GetString("LiveUSer");
            var user = JsonConvert.DeserializeObject<User>(userJson);
            var orders = _db.cart.Include(p => p.product)
                .Where(u => u.UserId == user.ID).ToList();
            if (true)
            {
                return View(orders);
            }

            Order order = new Order();
            double totalPrice = 0;

            foreach (var price in orders)
            {
                totalPrice += price.Quantity * price.product.Price * price.product.percentageOfDiscount;
            }
            order.Total = totalPrice;
            order.Date = DateTime.Now;
            order.Name = user.Name;
            order.Location = user.location;
            order.Email = user.Email;

            return View(order);
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
