using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            return _db.products != null ?
                        View(await _db.products.Where(p => p.percentageOfDiscount != 1).ToListAsync()) :
                        Problem("Entity set 'AplicationContext.product'  is null.");
        }

        public IActionResult Products(int id)
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
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Cart", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var products = _db.cart.Include(p => p.product)
                .Where(u => u.UserId == user.ID).ToList();

                return View(products);
            }



        }
        public IActionResult Checkout()
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Checkout", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var orders = _db.cart.Include(p => p.product)
                    .Where(u => u.UserId == user.ID).ToList();

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
                order.user = user;
                order.user.carts = _db.cart.Where(u => u.UserId == user.ID).ToList();
                return View(order);
            }
        }
        [HttpPost]
        public IActionResult Checkout(Order ord)
        {
            var obj = _db.payments.ToList();
            string? userJson = HttpContext.Session.GetString("LiveUser");
            var user = JsonConvert.DeserializeObject<User>(userJson);
            ord.userId = user.ID;
            ord.Date = DateTime.Now;
            foreach (var item in obj)
            {
                if (item.cardNo == ord.card && item.Password == ord.password)
                {
                    _db.orders.Add(ord);

                    _db.SaveChanges();

                    var cartsToDelete = _db.cart.Where(cart => cart.UserId == user.ID);
                    _db.cart.RemoveRange(cartsToDelete);
                    _db.SaveChanges();

                    TempData["success"] = "Payment processed successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["error"] = "Payment does't work";
            return View();
        }

        public IActionResult Order()
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Order", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);

                var orders = _db.orders.Include(u => u.user)
                    .Where(o => o.userId == user.ID).ToList();

                return View(orders);
            }
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            List<FeedbackForWeb> obj = _db.feedbackForWebs.Where(s => s.Status == true).ToList();
            return View(obj);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("AddToCart", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var cart = new Cart();
                cart.UserId= user.ID;
                cart.productId = id;
                _db.cart.Add(cart);
                _db.SaveChanges();
                TempData["success"] = "product Add to Cart successfully";
                return RedirectToAction("Index");
            }


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LiveUser");
            return RedirectToAction("Index");
        }

    }
}
