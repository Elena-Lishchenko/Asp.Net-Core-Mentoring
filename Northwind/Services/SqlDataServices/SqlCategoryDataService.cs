using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	internal class SqlCategoryDataService : ICategoryDataService
	{
		private readonly NorthwindContext _context;

		public SqlCategoryDataService(NorthwindContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Category>> AllCategories()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<Category> Find(int? id)
		{
			return await _context.Categories.FindAsync(id);
		}
	}
}