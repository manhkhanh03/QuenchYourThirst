using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context) { _context = context; }

        private async Task<List<ProductCategory>> PC()
        {
            var categories = await (from item in _context.ProductCategorys
                                    select new ProductCategory()
                                    {
                                        name = item.name,
                                        id = item.id
                                    }).ToListAsync();

            categories.Insert(0, new ProductCategory()
            {
                name = "----- Chọn -----",
                id = 0,
            });
            return categories;
        }

        private async Task<List<StatusProduct>> PS()
        {
            var status = await (from item in _context.StatusProducts
                                where item.name != "Xoá"
                                select new StatusProduct()
                                {
                                    name = item.name,
                                    id = item.id
                                }).ToListAsync();

            status.Insert(0, new StatusProduct()
            {
                name = "----- Chọn -----",
                id = 0,
            });
            return status;
        }

        private async Task<Dictionary<string, object>> Fl(long? id = null)
        {
            var flavors = await (from item in _context.Flavors
                                 select new
                                 {
                                     id = item.id,
                                     name = item.name,
                                     type_flavor_id = item.type_flavor_id,
                                     isActive = id == item.id ? true : false
                                 }).ToListAsync();
            flavors.Insert(0, new {
                id = (long)0,
                name = "----- Chọn -----",
                type_flavor_id = (long)0, 
                isActive = false,
            });
            var typeFlavor = await (from item in _context.TypeFlavors select item).ToListAsync();
            typeFlavor.Insert(0, new TypeFlavor()
            {
                name = "----- Chọn -----",
                id = 0,
            });
            return new Dictionary<string, object> {
                { "flavors", flavors },
                { "typeFlavors", typeFlavor },
            };
        }

        public class SizePrice
        {
            public long id { get; set; }
            public long idpsf { get; set; }
            public string name { get; set; }
            public decimal price { get; set; }
            public bool isActive { get; set; }
        }

        public async Task<List<SizePrice>> Si(long? id = null)
        {
            var sizes = await (from item in _context.Sizes
                               //join psf in _context.ProductSizeFlavors on item.id equals psf.size_id
                               //where psf.product_id == id || id == null
                               select new SizePrice
                               {
                                   id = item.id,
                                   name = item.name,
                                   isActive = false,
                               }).ToListAsync();
            sizes.Insert(0, new SizePrice()
            {
                id = 0,
                name = "----- Chọn -----",
                isActive = false,
            });
            if (id != null && id != 0) { 
                foreach (var item in sizes)
                {
                    var price = await (from i in _context.ProductSizeFlavors
                                       where i.product_id == id && item.id == i.size_id
                                       select i.price).FirstOrDefaultAsync();

                    item.price = price;
                    item.isActive = price == 0 ? false : true;
                }
            } 
            return sizes;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await PC();
            ViewBag.Status = await PS();
            ViewBag.Flavors = await Fl();
            ViewBag.Sizes = await Si();
            ViewData["actionName"] = "create";
            ViewData["controllerName"] = "product";

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Product product)
        {

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            return BadRequest(product);
        }

        [HttpGet]
        public IActionResult All()
        {
            var products = (from p in _context.Products
                            join i in _context.ProductImages on p.id equals i.product_id
                            select new
                            {
                                products = p,
                                images = i
                            });
            ViewData["actionName"] = "all";
            ViewData["controllerName"] = "product";
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var product = _context.Products.Find(id);
            if (product == null || id == 0) return Redirect("/not-found");
            ViewBag.Categories = await PC();
            ViewBag.Status = await PS();
            ViewBag.Flavors = await Fl(id);
            ViewBag.Sizes = await Si(id);

            ViewData["actionName"] = "edit";
            ViewData["controllerName"] = "product";
            return View(product);
        }

    }
}
