using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyRazorWeb_Temp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyRazorWeb_Temp.Models;

namespace BulkyRazorWeb_Temp.Pages.Categories
{
	public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public List<Category> categoryList { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

            categoryList = _db.Categories.ToList();

        }
    }
}
