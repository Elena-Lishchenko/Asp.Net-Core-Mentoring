using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.ViewModels
{
	public class ProductForEditViewModel
	{
		public ProductForEditViewModel()
		{
			Categories = new List<CategoryViewModel>();
			Suppliers = new List<SupplierViewModel>();
		}

		public ProductViewModel Product { get; set; }
		public List<CategoryViewModel> Categories { get; set; }
		public List<SupplierViewModel> Suppliers { get; set; }
	}
}
