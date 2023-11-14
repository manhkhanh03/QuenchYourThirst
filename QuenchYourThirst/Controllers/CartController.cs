using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context) { _context = context; }
        public IActionResult Index()
        {
            //if (!Functions.isLogin()) return RedirectToAction("Index", "login");

            //var userId = Functions._Id;
            var userId = 10;
            var userCart = _context.Carts.Where(u => (u.customer_id == userId) && (u.status_cart_id == 1)).ToList();
            return View(userCart);
        }

        public IActionResult Create(Cart cart)
        {
            if (!Functions.isLogin()) return Redirect("/login");

            if (ModelState.IsValid)
            {
                _context.Carts.Add(cart);
                _context.SaveChanges();
                return Ok(new
                {
                    next_page = "/cart",
                });
            }
            return BadRequest(cart);
        }

        public IActionResult Delete(Cart cart)
        {
            var id = cart.id;
            var findCart = _context.Carts.Find(id);
            if (findCart != null) return BadRequest(new
            {
                message = "Không tìm thấy sản phẩm cần xoá!",
            });
            if (ModelState.IsValid)
            {
                _context.Carts.Update(cart);
                _context.SaveChanges();
                return Ok(new
                {
                    message = "Thành công!",
                });
            }
            return BadRequest(cart);
        }
    }
}
