using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public class MapSupplierService :ISupplierMappingService
	{
		private ISupplierDataService _supplierDataService;

		public MapSupplierService(ISupplierDataService supplierDataService)
		{
			_supplierDataService = supplierDataService;
		}

		public List<SupplierViewModel> MapSuppliers(IEnumerable<Supplier> suppliers)
		{
			var result = new List<SupplierViewModel>();
			foreach (var supplier in suppliers)
			{
				SupplierViewModel resultSupplier = MapSupplierToSupplierViewModel(supplier);
				result.Add(resultSupplier);
			}
			return result;
		}

		public SupplierViewModel MapSupplierToSupplierViewModel(Supplier supplier)
		{
			return new SupplierViewModel
			{
				SupplierID = supplier.SupplierID,
				CompanyName = supplier.CompanyName
			};
		}

		public async Task<SupplierViewModel> GetSupplierViewModelById(int id)
		{
			var supplier = await _supplierDataService.Find(id);
			return MapSupplierToSupplierViewModel(supplier);
		}
	}
}
