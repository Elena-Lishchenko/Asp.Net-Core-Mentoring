using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface ISupplierMappingService
	{
		List<SupplierViewModel> MapSuppliers(IEnumerable<Supplier> suppliers);
		SupplierViewModel MapSupplierToSupplierViewModel(Supplier supplier);
		Task<SupplierViewModel> GetSupplierViewModelById(int id);
	}
}
