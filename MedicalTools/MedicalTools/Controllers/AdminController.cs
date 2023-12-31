using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

            ViewBag.Customers = _context.users.Count();
            ViewBag.Oreders = _context.orders.Count();
            ViewBag.Total = _context.orders.Sum(order => order.Total);
            ViewBag.TotalReveneu = 0;
            if (_context.orders.Count() > 0)
            {
                ViewBag.TotalReveneu = _context.products.Sum(prodcut => prodcut.Cost * prodcut.percentageOfDiscount) - _context.orders.Sum(order => order.Total);
            }
            var orders=_context.orders.ToList();
            return View(orders);
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
            _context.categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }

        // ------- End Update



        // ------------------------------------------------------ END Categories CRUD






        // ------------------------------------------------------ Products CRUD



        public IActionResult Products()
        {
            List<Product>? products = _context.products
                .Include(p => p.Category)
                .ToList();
            return View(products);
        }



        // ------- Create
        public IActionResult CreatProduct()
        {
            IEnumerable<SelectListItem> categories = _context.categories.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.ID.ToString()
            });
            ViewBag.categoriesList = categories;

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

        public IActionResult DeleteProduct(int? id)
        {
            Product product = _context.products.FirstOrDefault(c => c.ID == id);
            _context.products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Products");

        }

        // ------- End Delete

        // ------- Update

        public IActionResult UpdateProduct(int? id)
        {

            Product product = _context.products.FirstOrDefault(c => c.ID == id);


            //IEnumerable<SelectListItem> categories = _context.categories.ToList().Select(u => new SelectListItem
            //{
            //    Text = u.Name,
            //    Value = product.categoryID.ToString()
            //});

            ViewBag.categoriesList = _context.categories.ToList();
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Products");

        }



        // ------------------------------------------------------ END Products CRUD



        // -------------------------------------------------------------------users
        public IActionResult Users()
        {
            List<User> Users = _context.users.ToList();
            return View(Users);
        }

        [HttpPost]
        public IActionResult Users(string SearchItem)
        {

            if (!string.IsNullOrEmpty(SearchItem))
            {
                List<User> searchUsers = _context.users.Where(u => u.Name.Contains(SearchItem)).ToList();
                return View(searchUsers);
            }

            List<User> allUsers = _context.users.ToList();
            return View(allUsers);


        }

        //--------------------------------------------------------------- Testimonials


        public IActionResult Testimonials()
        {

            List<FeedbackForWeb> FeedbackForWeb = _context.feedbackForWebs
                .Include(p => p.User).Where(p => p.Status == false)
                .ToList();
            return View(FeedbackForWeb);
        }

        public IActionResult DeleteTestimonials(int id)
        {
            var feedback = _context.feedbackForWebs.Find(id);
            _context.feedbackForWebs.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("Testimonials");

        }

        public IActionResult ApproveTestimonials(int id)
        {
            var feedback = _context.feedbackForWebs.Find(id);
            feedback.Status = true;
            _context.feedbackForWebs.Update(feedback);
            _context.SaveChanges();
            return RedirectToAction("Testimonials");

        }
    }
}
