using System;
using Microsoft.EntityFrameworkCore;
using BulkyRazorWeb_Temp.Models;

namespace BulkyRazorWeb_Temp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cat1", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Cat2", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Cat3", DisplayOrder = 3 }
                );
        }


    }

}
