using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
	public class Product
	{
		public int ProductID { get; set; }

		[Required, MaxLength(30)]
		public string ProductName { get; set; }
		public int CategoryID { get; set; }
		public int SupplierID { get; set; }
	}
}
