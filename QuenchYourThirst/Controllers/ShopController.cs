using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Models;
using System.Security.Cryptography;

namespace QuenchYourThirst.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataContext _context;
        public ShopController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/data/test")]
        public IActionResult DataTest()
        {
            var products = _context.Products.ToList();
            Random rand = new Random();

            foreach (var product in products)
            {
                product.product_category_id = rand.Next(1, 4);
                _context.Products.Update(product);
            }
            _context.SaveChanges();
            var productss = _context.Products.ToList();

            return Ok(products);
        }
    }
}
