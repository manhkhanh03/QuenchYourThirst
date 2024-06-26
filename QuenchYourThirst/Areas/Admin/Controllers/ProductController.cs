﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context) { _context = context; }

        public async Task<IActionResult> Index()
        {
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });
            var products = await (from p in _context.Products
                            join i in _context.ProductImages on p.id equals i.product_id
                            select new
                            {
                                products = p,
                                images = i,
                                psfs = _context.ProductSizeFlavors.Where(psf => psf.product_id == p.id).OrderBy(psf => psf.price).ToList(),
                                flavor = _context.Flavors.Where(f => f.id == _context.ProductSizeFlavors.Where(psf => p.id == psf.product_id).Select(psf => psf.flavor_id).FirstOrDefault()).FirstOrDefault(),
                                sizes = _context.Sizes.Where(s => _context.ProductSizeFlavors.Where(psf => p.id == psf.product_id).OrderBy(psf => psf.size_id).Select(psf => psf.size_id).Contains(s.id)).ToList(),
                                bought = _context.Carts.Where(c => _context.ProductSizeFlavors.Where(psf => p.id == psf.product_id).Select(psf => psf.id).Contains(c.product_size_flavor_id)).Count(),
                            }).ToListAsync();
            ViewData["actionName"] = "index";
            ViewData["controllerName"] = "product";

            var dropdown = new List<SelectListItem> {
                new SelectListItem()
                {
                    Text = "Tên sản phẩm",
                    Value = "1",
                },new SelectListItem()
                {
                    Text = "Trạng thái",
                    Value = "2",
                },new SelectListItem()
                {
                    Text = "Tồn kho",
                    Value = "3",
                },new SelectListItem()
                {
                    Text = "Giá",
                    Value = "4",
                },new SelectListItem()
                {
                    Text = "Loại sản phẩm",
                    Value = "5",
                },new SelectListItem()
                {
                    Text = "Kích thước",
                    Value = "6",
                },
            };

            ViewBag.SearchView = new
            {
                form = "#tbody",
                dropdown = dropdown,
            };
            return View(products);
        }

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
            public long psf { get; set; }
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
                id = (long)0,
                name = "----- Chọn -----",
                isActive = false,
            });
            if (id != null && id != 0) { 
                foreach (var item in sizes)
                {
                    var psf = await (from i in _context.ProductSizeFlavors
                                       where i.product_id == id && item.id == i.size_id
                                       select i).FirstOrDefaultAsync();
                    if (psf != null)
                    {
                        item.price = psf.price;
                        item.psf = psf.id;
                        item.isActive = psf.price == 0 ? false : true;
                    }
                }
            } 
            return sizes;
        }
        public async Task<ProductImage> Img (long? id =  null) {
            var img = await (from item in _context.ProductImages where item.product_id == id select item).FirstOrDefaultAsync();
            return img;
        }

        public async Task<List<ProductSizeFlavor>> PSF(long id)
        {
            var psf = await (from item in _context.ProductSizeFlavors
                             where item.product_id == id
                             select item).ToListAsync();
            return psf;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

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
                Functions._Message = "Thêm sản phẩm thành công!";
                return Ok(product);
            }
            return BadRequest(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

			var product = _context.Products.Find(id);
            if (product == null || id == 0) return Redirect("/not-found");
            ViewBag.Categories = await PC();
            ViewBag.Status = await PS();
            ViewBag.Flavors = await Fl(id);
            ViewBag.Sizes = await Si(id);
            ViewBag.Image = await Img(id);
            ViewBag.PSF = await PSF(id);

            ViewData["actionName"] = "edit";
            ViewData["controllerName"] = "product";
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit([FromBody] Product product) {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                Functions._Message = "Sửa sản phẩm thành công!";
                return Ok(product);
            }
            return BadRequest(product);
        }

        [HttpGet]
        public IActionResult Delete(long? id)
        {
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

			var product = _context.Products.Find(id);
            if (product == null || id == 0) { return BadRequest("/not-found"); }

            ViewData["actionName"] = "";
            ViewData["controllerName"] = "product";

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var p = _context.Products.Find(id);
            if (p == null) return Redirect("/not-found");

            var statusDeleteId = _context.StatusProducts.Where(s => s.name == "Xoá").Select(s => s.id).FirstOrDefault();
            p.status_product_id = statusDeleteId;
            _context.Products.Update(p);
            _context.SaveChanges();
            Functions._Message = "Xoá sản phẩm thành công!";
            return Redirect("/admin/product/index");
        }
    }
}
