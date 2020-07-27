using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface IProductService
	{
		Task<ProductForEditViewModel> GetProductForEditViewModel(int id);
		Task SetCategoriesInProductForEdit(ProductForEditViewModel product);
		Task SetSuppliersInProductForEdit(ProductForEditViewModel product);
		Task<IEnumerable<ProductViewModel>> GetAllProducts(int maximumCount);
		Task<ProductViewModel> GetProductById(int id);
		Task Create(Product product);
		Task<bool> Edit(ProductViewModel product);
		Task Delete(int id);
		bool IsProductExists(int id);
	}
}
