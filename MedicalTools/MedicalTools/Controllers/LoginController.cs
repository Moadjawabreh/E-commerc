using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalTools.Controllers
{
    public class LoginController : Controller
    {
		private readonly ApplicationContext _context;

		public LoginController(ApplicationContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ActionName("Index")]
		public IActionResult Index_Post([Bind("Email", "Password")] User user)
		{
			var users = _context.users.ToList();
			foreach (var u in users)
			{
				if (u.Email == user.Email && u.Password == user.Password)
				{
					string userJson = JsonConvert.SerializeObject(u);
					HttpContext.Session.SetString("LiveUser", userJson);
					if (u.Role == Role.Admin)
					{
						return RedirectToAction("Index", "Admin");
					}
					else if (u.Role == Role.User)
					{
                        // Check if there is a return URL in TempData
                        var returnUrl = TempData["ReturnUrl"] as string;
                        // Redirect to the return URL or the default /Customer/Index
                        return Redirect(string.IsNullOrEmpty(returnUrl) ? "/Customer/Index" : returnUrl);
					}
				}
			}

			ModelState.AddModelError("InvalidUser", "Invalid email or password.");
			return View(user);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(User user)
		{
            var users = _context.users.ToList();
			bool check = false;
			foreach (var u in users)
			{
				if (u.Email.ToLower() == user.Email.ToLower())
				{
					check = true;
					break;
				}
			}
			if (!check)
			{
				string userJson = JsonConvert.SerializeObject(user);
				HttpContext.Session.SetString("LiveUser", userJson);
				user.Role = Role.User;
				_context.users.Add(user);
				_context.SaveChanges();
				return RedirectToAction("Index", "Customer");
			}
			TempData["error"] = "This Email is already used, please login";
			return RedirectToAction("Index");
			
		}
	}
}
