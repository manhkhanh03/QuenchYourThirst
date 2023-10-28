using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
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
        //    var products = new ProductSizeFlavor();
        //    Random rand = new Random();

        //    for(int i = 1; i <= 50; i++)
        //    {
        //        products.id = i + 67;
        //        products.product_id = rand.Next(1, 50);
        //        products.size_id = rand.Next(1,4);
        //        products.flavor_id = rand.Next(1, 16);
        //        products.price = rand.Next(10, 101);
        //        _context.ProductSizeFlavors.Add(products);
        //    _context.SaveChanges();
        //    }

        //    return Ok(products);
        
        //}

    }
}
