using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Controllers
{
	public class ProductController : Controller
	{
		private DataContext _context;
		public ProductController (DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		[Route("product/{product_name}/{id}")]
		public IActionResult Index([FromQuery] Dictionary<string, string> request, long id)
		{

			if (id == 0 || id == null)
				return Redirect("/not-found");
			var product = (from p in _context.Products
						   where p.id == id
						   select new
						   {
							   product = p,
							   psfs = _context.ProductSizeFlavors.Where(psf => psf.product_id == p.id).OrderBy(psf => psf.price).ToList(),
							   imgs = _context.ProductImages.Where(img => img.product_id == p.id).ToList(),
							   sizes = _context.ProductSizeFlavors.Where(psf => psf.product_id == p.id)
													   .Select(psf => _context.Sizes.FirstOrDefault(s => s.id == psf.size_id)).ToList(),
							   flavor = _context.ProductSizeFlavors.Where(psf => psf.product_id == p.id)
													   .Select(psf => _context.Flavors.FirstOrDefault(f => f.id == psf.flavor_id)).FirstOrDefault(),
						   }).FirstOrDefault();

			if (product == null) return Redirect("/not-found");
			var selectSize = new Size
			{
				id = 0,
				name = "Chọn size:"
			};
			product.sizes.Insert(0, selectSize);

			ViewBag.Product = product;
			return View();
		}
	}
}
