using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.Linq;

namespace QuenchYourThirst.Controllers
{
    public class CommentController : Controller
    {
        private readonly DataContext _context;
        public CommentController(DataContext context) { _context = context; }


        [HttpPost]
        public IActionResult Create([FromBody] Comment comment)
        {
            if (!Functions.isLogin()) return BadRequest(new
            {
                message = "Chưa đăng nhập! Bạn có muốn đăng nhập không?",
                next_page = "/login"
            });

			if (ModelState.IsValid)
			{
				_context.Comments.Add(comment);
				_context.SaveChanges();
                var cm = _context.Comments.Where(cm => cm.id == comment.id).Select(cm => new
                {
                    comment = cm,
                    user = _context.AdminUsers.Where(u => u.id == comment.user_id).FirstOrDefault(),
                }).FirstOrDefault();
				return Ok(cm);
			}
			return BadRequest(comment);
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
