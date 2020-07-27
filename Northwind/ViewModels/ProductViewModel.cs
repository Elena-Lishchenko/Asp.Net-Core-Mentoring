using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.ViewModels
{
	public class ProductViewModel
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public CategoryViewModel Category { get; set; }
		public SupplierViewModel Supplier { get; set; }
	}
}
