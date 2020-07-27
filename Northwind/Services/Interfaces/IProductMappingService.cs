using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface IProductMappingService
	{
		Task<IEnumerable<ProductViewModel>> MapProducts(IEnumerable<Product> products);
		Task<ProductViewModel> MapProductToProductViewModel(Product product);
		Task<ProductForEditViewModel> MapProductToProductForEditViewModel(Product product);
	}
}
