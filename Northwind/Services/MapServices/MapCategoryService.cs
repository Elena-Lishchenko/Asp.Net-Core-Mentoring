using Northwind.Models;
using Northwind.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
	public class MapCategoryService: ICategoryMappingService
	{
		private ICategoryDataService _categoryDataService;

		public MapCategoryService(ICategoryDataService categoryDataService)
		{
			_categoryDataService = categoryDataService;
		}

		public List<CategoryViewModel> MapCategories(IEnumerable<Category> categories)
		{
			var result = new List<CategoryViewModel>();
			foreach (var category in categories)
			{
				CategoryViewModel resultCategory = MapCategoryToCategoryViewModel(category);
				result.Add(resultCategory);
			}
			return result;
		}

		public CategoryViewModel MapCategoryToCategoryViewModel(Category category)
		{
			return new CategoryViewModel
			{
				CategoryID = category.CategoryID,
				CategoryName = category.CategoryName
			};
		}

		public async Task<CategoryViewModel> GetCategoryViewModelById(int id)
		{
			var category = await _categoryDataService.Find(id);
			return MapCategoryToCategoryViewModel(category);
		}
	}
}
