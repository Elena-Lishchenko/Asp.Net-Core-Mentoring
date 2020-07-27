using Northwind.Data;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	internal class SqlSupplierDataService : ISupplierDataService
	{
		private readonly NorthwindContext _context;

		public SqlSupplierDataService(NorthwindContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Supplier>> AllSuppliers()
		{
			return await _context.Suppliers.ToListAsync();
		}

		public async Task<Supplier> Find(int? id)
		{
			return await _context.Suppliers.FindAsync(id);
		}
	}
}