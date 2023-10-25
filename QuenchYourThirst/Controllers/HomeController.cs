using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuenchYourThirst.Models;
using System.Diagnostics;

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

        private int totalProduct()
        {
            var total = _context.Products.Count();
            return total;
        }

        [HttpGet]
        [Route("/{test}/{shop}")]
        public IActionResult Test([FromQuery] Dictionary<string, string> request)
        {
            int per_page = 0;
            int currentPage = 0;
            if (request.ContainsKey("pp") && int.TryParse(request["pp"], out per_page)){}
            if (request.ContainsKey("p") && int.TryParse(request["p"], out currentPage)) { }

            int offset = (currentPage - 1) * per_page;
            int limit = per_page;

            var products = (from psf in _context.ProductSizeFlavors
                            join p in _context.Products on psf.product_id equals p.id
                            join s in _context.Sizes on psf.size_id equals s.id
                            join f in _context.Flavors on psf.flavor_id equals f.id
                            join img in _context.ProductImages on p.id equals img.product_id
                            where p.status_product_id == 1 select new
                            {
                                psfs = psf,
                                products = p,
                                sizes = s,
                                flavors = f,
                                imgs = img,
                            }).Skip(offset).Take(limit).ToList();

            ViewData["totalPage"] = (int)(totalProduct() / limit);
            ViewData["currentPage"] = currentPage;
            return Ok(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}