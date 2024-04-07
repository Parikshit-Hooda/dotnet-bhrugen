using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyRazorWeb_Temp.Data;
using BulkyRazorWeb_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazorWeb_Temp.Pages.Categories
{
	public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(Category obj)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
