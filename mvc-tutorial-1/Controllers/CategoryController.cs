using Microsoft.AspNetCore.Mvc;
using mvc_tutorial_1.Data;
using mvc_tutorial_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc_tutorial_1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> category = _applicationDbContext.Catergory;
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) //Backend validation based on 'Category' model created rules
            {
                return View(category); 
            }
            _applicationDbContext.Add(category);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
