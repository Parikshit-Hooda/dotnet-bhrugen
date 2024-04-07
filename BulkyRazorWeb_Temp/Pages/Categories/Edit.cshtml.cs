using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyRazorWeb_Temp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BulkyRazorWeb_Temp.Models;

namespace BulkyRazorWeb_Temp.Pages.Categories
{
    [BindProperties]
	public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                return ;
            }

            Category = _db.Categories.Find(id);

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                //TempData["success"] = "update success";

            }
            return RedirectToAction("Index");


        }
    }
}
