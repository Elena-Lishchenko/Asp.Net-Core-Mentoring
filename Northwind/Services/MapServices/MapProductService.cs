using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	internal class MapProductService : IProductMappingService
	{
		public MapProductService(ICategoryMappingService categoryMappingService, ISupplierMappingService supplierMappingService)
		{
			_categoryMappingService = categoryMappingService;
			_supplierMappingService = supplierMappingService;
		}

		private ICategoryMappingService _categoryMappingService { get; set; }
		private ISupplierMappingService _supplierMappingService { get; set; }

		public async Task<IEnumerable<ProductViewModel>> MapProducts(IEnumerable<Product> products)
		{
			var result = new List<ProductViewModel>();
			foreach (var product in products)
			{
				ProductViewModel resultProduct = await MapProductToProductViewModel(product);
				result.Add(resultProduct);
			}
			return result;
		}

		public async Task<ProductViewModel> MapProductToProductViewModel(Product product)
		{
			var result = new ProductViewModel();
			result.ProductID = product.ProductID;
			result.ProductName = product.ProductName;
			result.Supplier = await _supplierMappingService.GetSupplierViewModelById(product.SupplierID);
			result.Category = await _categoryMappingService.GetCategoryViewModelById(product.CategoryID);
			return result;
		}

		public async Task<ProductForEditViewModel> MapProductToProductForEditViewModel(Product product)
		{
			var result = new ProductForEditViewModel();
			result.Product = await MapProductToProductViewModel(product);
			return result;
		}
	}
}