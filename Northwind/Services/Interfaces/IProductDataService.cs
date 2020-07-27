using Northwind.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface IProductDataService
	{
		Task<IEnumerable<Product>> AllProducts();
		Task<Product> Details(int? id);
		Task Create(Product product);
		Task Edit(Product product);
		Task<Product> Find(int? id);
		Task Delete(Product product);
		bool IsProductExists(int id);
	}
}
