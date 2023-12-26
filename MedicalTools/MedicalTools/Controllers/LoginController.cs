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
						return RedirectToAction("Index", "Customer");
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
		public async Task<IActionResult> Create([Bind("ID,Name,Email,Password")] User user)
		{
			if(ModelState.IsValid)
			{
				user.Role = Role.User;
				_context.users.Add(user);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Customer");
			}

			return View(user);
			
		}
	}
}
