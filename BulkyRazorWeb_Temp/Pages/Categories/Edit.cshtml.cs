using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyRazorWeb_Temp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BulkyRazorWeb_Temp.Pages.Categories
{
	public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
    }
}
