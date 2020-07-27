using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public interface ICategoryMappingService
	{
		List<CategoryViewModel> MapCategories(IEnumerable<Category> categories);
		CategoryViewModel MapCategoryToCategoryViewModel(Category category);
		Task<CategoryViewModel> GetCategoryViewModelById(int id);
	}
}
