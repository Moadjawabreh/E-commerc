using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalTools.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationContext _context;
        public AdminController(ApplicationContext context)
        {
        _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        // ------------------------------------------------------ Categories CRUD


        public IActionResult Categories()
        {
			List<Category>? categories = _context.categories.ToList();

            return View(categories);
        }

        // ------- Create
		public IActionResult CreatCategories()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatCategories(Category category)
		{
			return View(category);
		}
		// ------- End Create



		// ------- Delete

		public IActionResult DeleteCategories(int? categoryId)
		{
			return View();
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteCategories(Category category)
		{
			return View(category);
		}

		// ------- End Delete


		// ------- Update

		public IActionResult UpdateCategories(int? categoryId)
		{
			return View();
		}

		[HttpPost]
		public IActionResult UpdateCategories(Category category)
		{
			return View();
		}

		// ------- End Update



		// ------------------------------------------------------ END Categories CRUD






		// ------------------------------------------------------ Products CRUD



		public IActionResult Products()
        {
            return View();
        }



		// ------- Create
		public IActionResult CreatProduct()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreatProduct(Category category)
		{
			return View();
		}
		// ------- End Create



		// ------- Delete

		public IActionResult DeleteProduct(int? categoryId)
		{
			return View();
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteProduct(Category category)
		{
			return View();
		}

		// ------- End Delete


		// ------- Update

		public IActionResult UpdateProduct(int? categoryId)
		{
			return View();
		}

		[HttpPost]
		public IActionResult UpdateProduct(Category category)
		{
			return View();
		}



		// ------------------------------------------------------ END Products CRUD





		// -------------------------------------------------------------------users

		public IActionResult Users()
        {
            return View();
        }


		//---------------------------------------------------------------


        public IActionResult Testimonials() 
        {
            return View();
        }


    }
}
