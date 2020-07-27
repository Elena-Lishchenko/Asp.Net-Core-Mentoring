using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Northwind.Models;
using Northwind.Services;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
	public class ProductController : Controller
	{
		private IProductService _productService;
		private IConfiguration _config;

		public ProductController(IProductService productService, IConfiguration config)
		{
			_productService = productService;
			_config = config;
		}


		// GET: Products
		public async Task<IActionResult> AllProducts()
		{
			var products = await _productService.GetAllProducts(_config.GetValue<int>("MaximumProducts"));
			return View(products);
		}

		// GET: Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _productService.GetProductById(id.Value);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Products/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ProductID,ProductName,CategoryID,SupplierID")] Product product)
		{
			if (ModelState.IsValid)
			{
				await _productService.Create(product);
				return RedirectToAction(nameof(AllProducts));
			}
			return View(product);
		}

		// GET: Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _productService.GetProductForEditViewModel(id.Value);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ProductViewModel product)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await _productService.Edit(product);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!IsProductExists(product.ProductID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(AllProducts));
			}
			return View(product);
		}

		// GET: Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _productService.GetProductById(id.Value);

			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _productService.Delete(id);
			return RedirectToAction(nameof(AllProducts));
		}

		private bool IsProductExists(int id)
		{
			return _productService.IsProductExists(id);
		}
	}
}
