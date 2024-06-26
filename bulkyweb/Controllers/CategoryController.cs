﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bulky.DataAccess;
using Bulky.Models;
using Bulky.DataAccess.Data;

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
                TempData["success"] = "create success";
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
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(e => e.Id == id);
            //Category categoryFromDb2 = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "update success";
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category categoryFromDb = _db.Categories.Find(id); //find only works on primary key
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(e => e.Id == id);
            //Category categoryFromDb2 = _db.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            if (id == null || id == 0) return NotFound();

            Category obj = _db.Categories.Find(id);

            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "delete success";
                return RedirectToAction("Index");

            }

            return View();
        }


    }
}

