using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Hosting;
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
            //if (category.ImageFile != null)
            //{
            //	string wwwRootPath = webHostEnvironment.WebRootPath;
            //	string fileName = Guid.NewGuid().ToString() + "" +
            //             category.ImageFile.FileName;
            //	string path = Path.Combine(wwwRootPath + "/Image/", fileName);
            //	using (var fileStream = new FileStream(path, FileMode.Create))
            //	{
            //                 category.ImageFile.CopyTo(fileStream);
            //	}
            //             category.imageUrl = fileName;
            //}

            if (category != null)
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View();
        }
        // ------- End Create



        // ------- Delete

        public IActionResult DeleteCategories(int? id)
        {

            Category category = _context.categories.FirstOrDefault(c => c.ID == id);
            _context.categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Categories");

        }

        //[HttpPost, ActionName("DeleteCategories")]
        //public IActionResult DeleteCategories(Category category)
        //{
        //	_context?.categories.Remove(category);
        //	_context?.SaveChanges();

        //	return RedirectToAction("Categories");
        //}

        // ------- End Delete


        // ------- Update

        public IActionResult UpdateCategories(int? id)
        {
			Category category = _context.categories.FirstOrDefault(c => c.ID == id);

			return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategories(Category category)
        {

            _context?.categories.Update(category);
            _context?.SaveChanges();
            return RedirectToAction("Categories");
        }

		// ------- End Update



		// ------------------------------------------------------ END Categories CRUD






		// ------------------------------------------------------ Products CRUD



		public IActionResult Products()
        {
            List<Product>? products = _context.products.ToList();
            return View(products);
        }



        // ------- Create
        public IActionResult CreatProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatProduct(Product product)
        {
            if (product != null)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
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
