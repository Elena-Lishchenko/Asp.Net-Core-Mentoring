using Northwind.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface ISupplierDataService
	{
		Task<IEnumerable<Supplier>> AllSuppliers();
		Task<Supplier> Find(int? id);
	}
}
