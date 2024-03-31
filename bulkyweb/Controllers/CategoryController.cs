using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bulkyweb.Data;
using bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bulkyweb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: /<controller>/

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index");
            //return View();
        }

    }
}

