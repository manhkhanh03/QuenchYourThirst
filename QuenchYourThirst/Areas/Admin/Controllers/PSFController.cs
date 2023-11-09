using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PSFController : Controller
    {
        private readonly DataContext _context;
        public PSFController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] ProductSizeFlavor psf)
        {

            if (ModelState.IsValid)
            {
                _context.ProductSizeFlavors.Add(psf);
                _context.SaveChanges();
                return Ok(psf);
            }
            return BadRequest(psf);

        }
    }
}
