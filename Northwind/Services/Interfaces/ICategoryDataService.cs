using Northwind.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface ICategoryDataService
	{
		Task<IEnumerable<Category>> AllCategories();
		Task<Category> Find(int? id);
	}
}
