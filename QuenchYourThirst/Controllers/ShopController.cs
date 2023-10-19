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

        //[HttpGet]
        //[Route("/data/test")]
        //public IActionResult DataTest()
        //{
        //    var product = new ProductSizeFlavor();
        //    Random rand = new Random();
            
        //    for(int i = 1; i <= 50; i++)
        //    {
        //        product.id = i;
        //        product.product_id = i;
        //        product.size_id = rand.Next(1, 4);
        //        product.flavor_id = rand.Next(1, 16);
        //        product.price = rand.Next(10, 50);

        //        _context.ProductSizeFlavors.Add(product);
        //        _context.SaveChanges();
        //    }
        //    var products = _context.ProductSizeFlavors.ToList();

        //    return Ok(products);
        //}
    }
}
