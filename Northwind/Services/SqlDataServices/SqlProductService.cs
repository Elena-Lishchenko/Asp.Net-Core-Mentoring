using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Services
{
	internal class SqlProductService : IProductDataService
	{
		private readonly NorthwindContext _context;

		public SqlProductService(NorthwindContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Product>> AllProducts()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<Product> Details(int? id)
		{
			return await _context.Products
				.FirstOrDefaultAsync(m => m.ProductID == id);
		}

		public async Task Create(Product product)
		{
			_context.Add(product);
			await _context.SaveChangesAsync();
		}

		public async Task Edit(Product product)
		{
			_context.Update(product);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Product product)
		{
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}

		public async Task<Product> Find(int? id)
		{
			return await _context.Products.FindAsync(id);
		}

		public bool IsProductExists(int id)
		{
			return _context.Products.Any(e => e.ProductID == id);
		}
	}
}