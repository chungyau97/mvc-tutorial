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
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationTypeController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> applicationType = _applicationDbContext.ApplicationType;
            return View(applicationType);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            if (!ModelState.IsValid)
            {
                return View(applicationType);
            }
            _applicationDbContext.Add(applicationType);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            ApplicationType applicationType = _applicationDbContext.ApplicationType.Find(Id);
            if (applicationType == null)
            {
                return NotFound();
            }
            return View(applicationType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (!ModelState.IsValid)
            {
                return View(applicationType);
            }
            _applicationDbContext.ApplicationType.Update(applicationType);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }
            ApplicationType applicationType = _applicationDbContext.ApplicationType.Find(Id);
            if (applicationType == null)
            {
                return NotFound();
            }
            _applicationDbContext.ApplicationType.Remove(applicationType);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
