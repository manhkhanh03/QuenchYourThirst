

using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController: Controller
    {
        private readonly DataContext _context;
        public ProductImageController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] ProductImage pi)
        {

            if (ModelState.IsValid)
            {
                _context.ProductImages.Add(pi);
                _context.SaveChanges();
                return Ok(pi);
            }
            return BadRequest(pi);

        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] ProductImage pi)
        {

            if (ModelState.IsValid)
            {
                _context.ProductImages.Update(pi);
                _context.SaveChanges();
                return Ok(pi);
            }
            return BadRequest(pi);

        }
    }
}
