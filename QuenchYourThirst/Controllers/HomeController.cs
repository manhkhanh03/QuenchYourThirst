using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;


namespace QuenchYourThirst.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DataContext _context;

		public HomeController(ILogger<HomeController> logger, DataContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		private int totalProduct(long category)
		{
			var total = _context.Products.Where(p => p.product_category_id == category || category == 0).Count();
			return total;
		}

		private async Task<List<ProductCategory>> ProductCategoriesAsync()
		{
			var categories = await _context.ProductCategorys
				.ToListAsync();
			var allCategory = new ProductCategory
			{
				id = 0,
				name = "All"
			};

			categories.Insert(0, allCategory);
			return categories;
		}

		[HttpGet]
		[Route("/shop")]
		public async Task<IActionResult> Test([FromQuery] Dictionary<string, string> request)
		{
			int per_page = 0;
			int currentPage = 0;
			if (request.ContainsKey("pp") && int.TryParse(request["pp"], out per_page)) { }
			if (request.ContainsKey("p") && int.TryParse(request["p"], out currentPage)) { }
			per_page = per_page == 0 ? 24 : per_page;
			currentPage = currentPage == 0 ? 1 : currentPage;

			int offset = (currentPage - 1) * per_page;
			int limit = per_page;
			int category = request.ContainsKey("c") ? int.Parse(request["c"]) : 0;
			//var products = _context.ProductSizeFlavors
			//    .Include(psf => psf.Product)
			//        .ThenInclude(pc => pc.ProductCategory)
			//    .Where(psf => psf.Product.status_product_id == 1)
			//    .Where(psf => psf.Product.product_category_id == category || category == 0)
			//    .Select(psf => new
			//    {
			//        psfs = psf,
			//        products = psf.Product,
			//        imgs = psf.Product.ProductImage.First(),

			//    })
			//    .Skip(offset)
			//    .Take(limit)
			//    .ToList();
			var products = (from p in _context.Products
							join psf in _context.ProductSizeFlavors on p.id equals psf.product_id into psfGroup
							join img in _context.ProductImages on p.id equals img.product_id
							where p.status_product_id == 1
							where p.product_category_id == category || category == 0
							select new
							{
								prices = psfGroup.Select(psf => psf.price).OrderBy(psf => psf).ToList(),
								products = p,
								imgs = img,
							}).Skip(offset).Take(limit).ToList();

			ViewData["totalPage"] = (int)Math.Ceiling((double)totalProduct(category) / limit);
			ViewData["currentPage"] = currentPage;
			ViewBag.categories = await ProductCategoriesAsync();
			ViewData["category"] = category;

			var queryDictionary = QueryHelpers.ParseQuery(this.Request.QueryString.ToString());
			var countQueryString = queryDictionary;
			var queryStringC = queryDictionary;
			var queryStringP_PP = queryDictionary;
			if (request.ContainsKey("c"))
				queryStringC = queryDictionary.Where(p => p.Key != "c").ToDictionary(p => p.Key, p => p.Value);
			countQueryString = queryStringC;

			if (request.ContainsKey("p") && request.ContainsKey("pp"))
			{
				queryDictionary = queryDictionary.Where(p => p.Key != "p").ToDictionary(p => p.Key, p => p.Value);
				queryStringP_PP = queryDictionary.Where(p => p.Key != "pp").ToDictionary(p => p.Key, p => p.Value);
			}

			//ViewData["countQueryString"] = queryDictionary.Count;
			ViewData["countQueryString"] = countQueryString.Count;
			ViewData["c"] = new Uri(QueryHelpers.AddQueryString($"{this.Request.Host}{this.Request.Path}", queryStringC)).Query;
			ViewData["p_pp"] = new Uri(QueryHelpers.AddQueryString($"{this.Request.Host}{this.Request.Path}", queryStringP_PP)).Query;
			return View(products);
		}

		[HttpGet]
		[Route("/{product_name}/{id}")]
		public IActionResult Product([FromQuery] Dictionary<string, string> request, long id)
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
							   flavors = _context.ProductSizeFlavors.Where(psf => psf.product_id == p.id)
										.Select(psf => _context.Flavors.FirstOrDefault(f => f.id == psf.flavor_id)).ToList(),
						   }).First();

			if (product == null) return Redirect("/not-found");
			var selectSize = new Size
			{
				id = 0,
				name = "Chọn size:"
			};
			var selectFlavor = new Flavor
			{
				id = 0,
				name = "Chọn hương vị:"
			};
			product.sizes.Insert(0, selectSize);
			product.flavors.Insert(0, selectFlavor);

			return View(product);
		}

		[HttpGet]
		[Route("/not-found")]
		public IActionResult NotFound404()
		{
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}