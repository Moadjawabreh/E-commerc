using MedicalTools.Context;
using MedicalTools.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace MedicalTools.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            webHostEnvironment = environment;

        }

        public IActionResult Index()
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Index", "Admin");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                if (user.Role == Role.Admin)
                {


                    ViewBag.Customers = _context.users.Where(u => u.Role == Role.User).Count();
                    ViewBag.Oreders = _context.orders.Count();
                    ViewBag.Total = _context.orders.Sum(order => order.Total);
                    ViewBag.TotalReveneu = 0;

                    if (_context.orders.Count() > 0)
                    {
                        //ViewBag.TotalReveneu = _context.products.Sum(prodcut => prodcut.Cost * prodcut.percentageOfDiscount) - _context.orders.Sum(order => order.Total);
                        ViewBag.TotalReveneu = _context.orders.Sum(o => o.Total) - _context.orders.Sum(o => o.Cost);
                    }
                    var orders = _context.orders.ToList();
                    return View(orders);
                }
                else
                {
                    return RedirectToAction("Index", "Customer");
                }
            }
        }


        // ------------------------------------------------------ Categories CRUD


        public IActionResult Categories()
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Categories", "Admin");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Category>? categories = _context.categories.ToList();

                return View(categories);
            }
        }

        // ------- Create
        public IActionResult CreatCategories()
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("CreatCategories", "Admin");
                return RedirectToAction("Index", "Login");
            }
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
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("DeleteCategories", "Admin");
                return RedirectToAction("Index", "Login");
            }

            Category category = _context.categories.FirstOrDefault(c => c.ID == id);
            _context.categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Categories");

        }

        // ------- End Delete


        // ------- Update

        public IActionResult UpdateCategories(int? id)
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("UpdateCategories", "Admin");
                return RedirectToAction("Index", "Login");
            }
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
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Products", "Admin");
                return RedirectToAction("Index", "Login");
            }
            List<Product>? products = _context.products
                .Include(p => p.Category)
                .ToList();
            return View(products);
        }



        // ------- Create
        public IActionResult CreatProduct()
        {

            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("CreatProduct", "Admin");
                return RedirectToAction("Index", "Login");
            }
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
                if (product.ImageFile != null)
                {
                    string wwwRootPath = webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "" +
                    product.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        product.ImageFile.CopyTo(fileStream);
                    }
                    product.UrlImage = "/Image/" + fileName;

                }



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

            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("DeleteProduct", "Admin");
                return RedirectToAction("Index", "Login");
            }
            Product product = _context.products.FirstOrDefault(c => c.ID == id);
            _context.products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Products");

        }

        // ------- End Delete

        // ------- Update

        public IActionResult UpdateProduct(int? id)
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("UpdateProduct", "Admin");
                return RedirectToAction("Index", "Login");
            }
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

            if (product != null)
            {
                if (product.ImageFile != null)
                {
                    string wwwRootPath = webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "" +
                    product.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        product.ImageFile.CopyTo(fileStream);
                    }
                    product.UrlImage = "/Image/" + fileName;

                }



                _context.products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Products");

            }
            return View();

        }



        // ------------------------------------------------------ END Products CRUD



        // -------------------------------------------------------------------users
        public IActionResult Users()
        {

            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Users", "Admin");
                return RedirectToAction("Index", "Login");
            }
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

            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("Testimonials", "Admin");
                return RedirectToAction("Index", "Login");
            }
            List<FeedbackForWeb> FeedbackForWeb = _context.feedbackForWebs
                .Include(p => p.User).Where(p => p.Status == false)
                .ToList();
            return View(FeedbackForWeb);
        }

        public IActionResult DeleteTestimonials(int id)
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("DeleteTestimonials", "Admin");
                return RedirectToAction("Index", "Login");
            }
            var feedback = _context.feedbackForWebs.Find(id);
            _context.feedbackForWebs.Remove(feedback);
            _context.SaveChanges();
            return RedirectToAction("Testimonials");

        }

        public IActionResult ApproveTestimonials(int id)
        {
            string? userJson = HttpContext.Session.GetString("LiveUser");
            if (userJson == null)
            {
                TempData["ReturnUrl"] = Url.Action("ApproveTestimonials", "Admin");
                return RedirectToAction("Index", "Login");
            }
            var feedback = _context.feedbackForWebs.Find(id);
            feedback.Status = true;
            _context.feedbackForWebs.Update(feedback);
            _context.SaveChanges();
            return RedirectToAction("Testimonials");

        }
    }
}
