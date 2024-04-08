using Bulky.Models;
using Microsoft.EntityFrameworkCore;


namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Cat1", DisplayOrder = 1 },
				new Category { Id = 4, Name = "Cat2", DisplayOrder = 2 },
				new Category { Id = 3, Name = "Cat3", DisplayOrder = 3 }

				);
			//this seed data truncates the already existing data
        }

    }
}

