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

            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "display order should not be a string");
            }

            if(ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Edit(int? id)
        {

            if(id == null || id == 0)
            {
                return NotFound();
            }

            Category categoryFromDb = _db.Categories.Find(id); //find only works on primary key
            Category categoryFromDb1 = _db.Categories.FirstOrDefault(e => e.Id == id);
            Category categoryFromDb2 = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "display order should not be a string");
            //}

            //if (ModelState.IsValid)
            //{
            //    _db.Categories.Add(obj);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");

            //}

            return View();
        }


    }
}

