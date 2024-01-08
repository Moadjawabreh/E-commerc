using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;

namespace MedicalTools.Controllers
{
    public class CustomerController : Controller
    {


        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CustomerController(ApplicationContext db, IWebHostEnvironment environment)
        {
            _db = db;
            webHostEnvironment = environment;
        }
        public IActionResult Index()
        {
            var products = _db.products.Include(p => p.Category).ToList();
            return View(products);
        }

        [ActionName("Product")]
        public IActionResult Products(int id)
        {
            var products = _db.products.Include(p => p.Category).Where(p => p.categoryID == id).ToList();
            return View(products);
        }



        public IActionResult SingleProduct(int id)
        {
            if (id != 0)
            {
                Product? product = _db.products
                    .Include(p => p.FeedbackForProducts)
                    .ThenInclude(f => f.User)
                    .SingleOrDefault(p => p.ID == id);

                ViewBag.seveProducts = _db.products.Where(p => p.categoryID == product.categoryID).Take(4).ToList();
                return View(product);

            }
            return View();

        }
        public IActionResult Profile()
        {
            TempData.Remove("ReturnUrl");
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Profile", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var userSession = JsonConvert.DeserializeObject<User>(userJson);
                var user = _db.users.Find(userSession.ID);
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            if (user.ImageFile != null)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "" +
                user.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    user.ImageFile.CopyTo(fileStream);
                }
                user.ImageUrl = "/Image/" + fileName;
            }

            _db.Update(user);
            _db.SaveChanges();
            return View(user);
        }

        public IActionResult Cart()
        {
            TempData.Remove("ReturnUrl");
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
        public IActionResult DeleteCart(int id)
        {
            var cart = _db.cart.Find(id);
            _db.Remove(cart);
            _db.SaveChanges();
            return RedirectToAction("Cart");
        }
        public IActionResult Checkout()
        {
            TempData.Remove("ReturnUrl");
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Checkout", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var carts = _db.cart.Include(p => p.product)
                    .Where(u => u.UserId == user.ID).ToList();

                Order order = new Order();
                double totalPrice = 0;
                double costs = 0;

                foreach (var cart in carts)
                {
                    totalPrice += cart.Quantity * cart.product.Price * cart.product.percentageOfDiscount;
                    costs += cart.product.Cost * cart.Quantity;
                }
                order.Total = totalPrice;
                order.Date = DateTime.Now;
                order.Cost = costs;
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
            TempData.Remove("ReturnUrl");
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
            List<FeedbackForWeb> obj = _db.feedbackForWebs.Include(f => f.User).Where(s => s.Status == true).ToList();
            return View(obj);
        }

        public IActionResult AddToCart(int id, int quantity)
        {
            TempData.Remove("ReturnUrl");
            
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("AddToCart", "Customer", new { id = id, quantity = quantity });
                return RedirectToAction("Index", "Login");
            }
            else
            {
                
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var carts = _db.cart.Where(c => c.UserId == user.ID).ToList();
                foreach (var item in carts)
                {
                    if (item.productId == id)
                    {
                        if (quantity != 0)
                            item.Quantity += quantity;
                        else
                            item.Quantity++;
                        _db.cart.Update(item);
                        _db.SaveChanges();
                        TempData["success"] = "product Add to Cart successfully";
                        return RedirectToAction("SingleProduct", new { ID = id });
                    }
                }

                var cart = new Cart();
                if (quantity == null || quantity == 0)
                {
                    cart.Quantity = 1;

                }
                else
                {
                    cart.Quantity = quantity;
                }
                cart.UserId = user.ID;
                cart.productId = id;
                _db.cart.Add(cart);
                _db.SaveChanges();
                TempData["success"] = "product Add to Cart successfully";
                return RedirectToAction("SingleProduct", new { ID = id });
            }


        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LiveUser");

            return RedirectToAction("Index");
        }


        public IActionResult AddFeedbackForProduct() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFeedbackForProduct(string reviewInput, int ID)
        {
            TempData.Remove("ReturnUrl");
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("SingleProduct", "Customer", new { id = ID });
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);

                int productId = ID; // Replace with the actual product ID



                FeedbackForProduct feedbackForProduct = new FeedbackForProduct();
                feedbackForProduct.Text = reviewInput;
                feedbackForProduct.userID = user.ID;
                feedbackForProduct.productID = ID;
                _db.feedbackForProducts.Add(feedbackForProduct);
                _db.SaveChanges();
                TempData["success"] = "Added FeedBack successfully";
                return RedirectToAction("SingleProduct", new { ID = productId });
            }
        }


        public IActionResult AddFeedbackForWeb() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeedbackForWeb(string reviewInput)
        {

            TempData.Remove("ReturnUrl");
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("About", "Customer");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                var feedBackForWeb = new FeedbackForWeb();
                feedBackForWeb.userID = user.ID;
                feedBackForWeb.Text = reviewInput;
                _db.feedbackForWebs.Add(feedBackForWeb);
                _db.SaveChanges();
                TempData["success"] = "Added FeedBack successfully";
                return RedirectToAction("About");
            }
        }



    }
}
