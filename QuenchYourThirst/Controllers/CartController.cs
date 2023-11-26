using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.Linq;

namespace QuenchYourThirst.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _context;
        public CartController(DataContext context) { _context = context; }
        public IActionResult Index()
        {
            if (!Functions.isLogin()) return RedirectToAction("index", "login");
            var userId = Functions._Id;
            var userCart = (from item in _context.Carts
                            join psf in _context.ProductSizeFlavors on item.product_size_flavor_id equals psf.id
                            join p in _context.Products on psf.product_id equals p.id
							where item.customer_id == userId && item.status_cart_id == 1
                            select new
                            {
                                cart = item,
                                flavor = (from f in _context.Flavors where f.id == psf.flavor_id select f.name).FirstOrDefault(),
                                size = (from s in _context.Sizes where s.id == psf.size_id select s.name).FirstOrDefault(),
                                image = (from pi in _context.ProductImages where p.id == pi.product_id select pi.url).FirstOrDefault(),
                                product = p,
							}
                            ).ToList(); 
            //return Ok(userCart);
            return View(userCart);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cart cart)
        {
            if (!Functions.isLogin()) return BadRequest(new
            {
                message = "Chưa đăng nhập! Bạn có muốn đăng nhập không?",
                next_page = "/login"
            });

            if (ModelState.IsValid)
            {
                _context.Carts.Add(cart);
                _context.SaveChanges();
                Functions._Message = "Thêm vào giỏ hàng thành công!";
                return Ok(new
                {
                    next_page = "/cart",
                });
            }
            return BadRequest(cart);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            if (id == 0 || id == null) return BadRequest(new
			{
				message = "Không tìm thấy sản phẩm cần xoá!",
			});
			//var cart = _context.Carts.Find((int)id);
            var cart = (from c in _context.Carts where c.id == id select c).FirstOrDefault();
            if (cart == null && Functions._Id == cart.customer_id) return BadRequest(new
            {
                message = "Không tìm thấy sản phẩm cần xoá!",
            });
            cart.status_cart_id = 3;
            _context.Carts.Update(cart);
            _context.SaveChanges();
            Functions._Message = "Xoá sản phẩm khỏi giỏ hàng thành công!";
            return Ok(new
            {
                message = "Xoá sản phẩm khỏi giỏ hàng thành công!",
            });
        }

        [HttpPost] 
        public IActionResult Contact([FromBody] Dictionary<string, string> request) 
        {
            Functions._AddressCart = request["address"];
            Functions._PhoneCart = request["phone"];
            return Ok(new { message = "Xác nhận thông tin liên lạc thành công!" });
		}

		[HttpPost]
		public IActionResult Checkout(Dictionary<string, string> request)
		{
            //return Ok(request);
			Functions._SubTotal = Convert.ToDecimal(request["subtotal"]);
			Functions._Total = Convert.ToDecimal(request["total"]);
			Functions._Delivery = Convert.ToDecimal(request["delivery"]);
			Functions._Discount = Convert.ToDecimal(request["discount"]);

			string[] strQuantityElements = request["quantity"].Split(",");
			Functions._QuantityCart = Array.ConvertAll(strQuantityElements, long.Parse);

			string[] strElements = request["cart_id"].Split(",");
			Functions._Cart_id = Array.ConvertAll(strElements, long.Parse);
			return RedirectToAction("index", "checkout");
		}
	}
}
