﻿using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
			return View();
		}


        [ActionName("Product")]
        public IActionResult Products(int id)
		{
            var products = _db.products.Include(p => p.Category).Where(p => p.categoryID == id);
            return View(products);
        }

		public IActionResult SingleProduct()
		{
			return View();
		}
		public IActionResult Cart()
		{

			// id for current user must fill from session
			string? userJson = HttpContext.Session.GetString("LiveUser");
			var user = JsonConvert.DeserializeObject<User>(userJson);
			if (user != null)
			{
				var products = _db.cart.Include(p => p.product)
				.Where(u => u.UserId == user.ID).ToList();

				return View(products);
			}

			TempData["ReturnUrl"] = Url.Action("Cart", "Customer");
			return RedirectToAction("Index", "Login");

		}
		public IActionResult Checkout()
		{
			string? userJson = HttpContext.Session.GetString("LiveUser");
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
			if (user != null)
			{
				return View(order);
			}
			TempData["ReturnUrl"] = Url.Action("Checkout", "Customer");
			return RedirectToAction("Index", "Login");
		}
		[HttpPost]
		public IActionResult Checkout(Order ord)
		{
			var obj = _db.payments.ToList();
			string? userJson = HttpContext.Session.GetString("LiveUser");
			var user = JsonConvert.DeserializeObject<User>(userJson);

			//ord.Total = 0;
			//var cart = _db.cart
			//    .Where(u=>u.UserId == user.ID)
			//    .ToList();
			//foreach(var cartItem in cart)
			//{
			//    ord.Total += cart
			//}
			//ord.Total = _db.cart.Where(u=> u.UserId == user.)
			ord.userId = user.ID;
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
			string? userJson = HttpContext.Session.GetString("LiveUSer");
			var user = JsonConvert.DeserializeObject<User>(userJson);
			if (user != null)
			{
				var orders = _db.orders.Include(u => u.user)
					.Where(o => o.userId == user.ID).ToList();

				return View(orders);
			}
			TempData["ReturnUrl"] = Url.Action("Order", "Customer");
			return RedirectToAction("Index", "Login");
		}
		public IActionResult Contact()
		{
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

		public IActionResult Profile()
		{
			string? userJson = HttpContext.Session.GetString("LiveUser");
			var userSession = JsonConvert.DeserializeObject<User>(userJson);
			var user = _db.users.Find(userSession.ID);
			return View(user);
			//var user = new User();
			//return View(user);
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
				user.ImageUrl = "/Image/"+fileName;
			}

			_db.Update(user);
			_db.SaveChanges();
			return View(user);
        }



    }
}
