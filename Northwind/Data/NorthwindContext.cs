using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.Data
{
	public class NorthwindContext : DbContext
	{
		public NorthwindContext (DbContextOptions<NorthwindContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
	}
}
