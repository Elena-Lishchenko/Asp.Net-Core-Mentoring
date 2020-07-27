using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public class ProductService :IProductService
	{
		private ICategoryDataService _categoryDataService;
		private ICategoryMappingService _categoryMappingService;
		private ISupplierMappingService _supplierMappingService;
		private ISupplierDataService _supplierDataService;
		private IProductMappingService _productMappingService;
		private IProductDataService _productDataService;

		public ProductService(IProductDataService productDataService,ICategoryDataService categoryDataService, ICategoryMappingService categoryMappingService, ISupplierMappingService supplierMappingService, ISupplierDataService supplierDataService, IProductMappingService productMappingService)
		{
			_categoryDataService = categoryDataService;
			_categoryMappingService = categoryMappingService;
			_supplierMappingService = supplierMappingService;
			_supplierDataService = supplierDataService;
			_productMappingService = productMappingService;
			_productDataService = productDataService;
		}

		public async Task<IEnumerable<ProductViewModel>> GetAllProducts(int maximumCount)
		{
			var products = await _productDataService.AllProducts();
			if (maximumCount > 0)
			{
				products = products.Take(maximumCount);
			}
			return await _productMappingService.MapProducts(products);
		}

		public async Task<ProductViewModel> GetProductById(int id)
		{
			var result = await _productDataService.Details(id);
			if (result == null)
			{
				return null;
			}
			return await _productMappingService.MapProductToProductViewModel(result);
		}

		public async Task Create(Product product)
		{
			await _productDataService.Create(product);
		}

		public async Task<bool> Edit(ProductViewModel product)
		{
			var findedProduct = await _productDataService.Find(product.ProductID);
			if (findedProduct == null)
			{
				return false;
			}
			findedProduct.ProductName = product.ProductName;
			findedProduct.CategoryID = product.Category.CategoryID;
			findedProduct.SupplierID = product.Supplier.SupplierID;

			await _productDataService.Edit(findedProduct);
			return true;
		}

		public async Task Delete (int id)
		{
			var product = await _productDataService.Find(id);
			await _productDataService.Delete(product);
		}

		public bool IsProductExists(int id)
		{
			return _productDataService.IsProductExists(id);
		}

		public async Task<ProductForEditViewModel> GetProductForEditViewModel(int id)
		{
			var product = await _productDataService.Find(id);
			if (product==null)
			{
				return null;
			}
			var result = await _productMappingService.MapProductToProductForEditViewModel(product);
			await SetSuppliersInProductForEdit(result);
			await SetCategoriesInProductForEdit(result);
			return result;
		}

		public async Task SetCategoriesInProductForEdit(ProductForEditViewModel product)
		{
			var categories = await _categoryDataService.AllCategories();
			product.Categories = _categoryMappingService.MapCategories(categories);
		}

		public async Task SetSuppliersInProductForEdit(ProductForEditViewModel product)
		{
			var suppliers = await _supplierDataService.AllSuppliers();
			product.Suppliers = _supplierMappingService.MapSuppliers(suppliers);
		}
	}
}
