using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BulkyRazorWeb_Temp.Data;
using BulkyRazorWeb_Temp.Models;

namespace BulkyRazorWeb_Temp.Pages.Categories
{
    [BindProperties]
	public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            Category = _db.Categories.Find(id);

        }

        public IActionResult OnPost(int? id)
        {

            Category obj = _db.Categories.Find(Category.Id);

            if (id == null) return NotFound();


            if (ModelState.IsValid)
            {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                //TempData["success"] = "delete success";

            }
            return RedirectToAction("Index");

        }

    }
}
