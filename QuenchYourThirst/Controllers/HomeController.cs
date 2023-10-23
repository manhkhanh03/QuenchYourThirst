using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.WebUtilities;


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
            var total = _context.Products.Where(p => p.product_category_id == category).Count();
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
        [Route("/{test}/{shop}")]
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
            var products = _context.ProductSizeFlavors
                .Include(psf => psf.Product)
                    .ThenInclude(pc => pc.ProductCategory)
                .Where(psf => psf.Product.status_product_id == 1)
                .Where(psf => psf.Product.product_category_id == category || category == 0)
                .Select(psf => new
                {
                    psfs = psf,
                    products = psf.Product,
                    imgs = psf.Product.ProductImage.First(),

                })
                .Skip(offset)
                .Take(limit)
                .ToList();



            ViewData["totalPage"] = (int)Math.Ceiling((double)totalProduct(category) / limit);
            ViewData["currentPage"] = currentPage;
            ViewBag.categories = await ProductCategoriesAsync();
            ViewData["category"] = category;

            var fullUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}{this.Request.QueryString}";
            // Parse the query string
            var queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(this.Request.QueryString.ToString());
            // Remove all 'c' parameters
            queryDictionary = queryDictionary.Where(p => p.Key != "c").ToDictionary(p => p.Key, p => p.Value);
            // Construct new URL without 'c' parameters
            var newUrl = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString($"{this.Request.Scheme}://{this.Request.Host}{this.Request.Path}", queryDictionary);

            ViewData["url"] = newUrl;

            return View(products);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}