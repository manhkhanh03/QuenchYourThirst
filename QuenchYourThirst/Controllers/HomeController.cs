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

            var queryDictionary = QueryHelpers.ParseQuery(this.Request.QueryString.ToString());
            var queryStringC = queryDictionary;
            var queryStringP_PP = queryDictionary;
            if (request.ContainsKey("c"))
                queryStringC = queryDictionary.Where(p => p.Key != "c").ToDictionary(p => p.Key, p => p.Value);
            if (request.ContainsKey("p") && request.ContainsKey("pp")) {
                queryDictionary = queryDictionary.Where(p => p.Key != "p").ToDictionary(p => p.Key, p => p.Value);
                queryStringP_PP = queryDictionary.Where(p => p.Key != "pp").ToDictionary(p => p.Key, p => p.Value);
            }

            ViewData["countQueryString"] = queryDictionary.Count;
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
            var product = _context.ProductSizeFlavors
                .Include(psf => psf.Product)
                    .ThenInclude(p => p.ProductImage)
                .Include(psf => psf.Size)
                .Include(psf => psf.Flavor)
                .Where(psf => psf.Product.id == id)
                .Where(psf => psf.Product.status_product_id == 1).FirstOrDefault();
                // sửa lại đoạn ni lấy sản phẩm đầu tiên và nhiều bản ghi khác các bảng khác ví dụ: product  là 1 object và các bảng khác là 1 mảng
            if (product == null) return Redirect("/not-found");
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