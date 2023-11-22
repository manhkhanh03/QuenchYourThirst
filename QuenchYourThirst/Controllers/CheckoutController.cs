using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly DataContext _context;
        public CheckoutController(DataContext context) {  _context = context; }
        public IActionResult Index()
        {
            var pm = _context.PaymentMethods.ToList();
            ViewBag.PaymentMethods = pm;
			return View();
        }

        public bool CreateOrderCart(long order_id)
        {
            
            try
            {
				foreach (var cart in Functions._Cart_id)
				{
					var orderCart = new OrderCart
					{
						cart_id = cart,
						order_id = order_id
					};
					_context.OrderCarts.Add(orderCart);
					_context.SaveChanges();
				}
				return true;
			}
            catch (Exception ex)
            {
                return false;
            }
        } 

        public bool EditCart()
        {
            try
            {
				for (int i = 0; i < Functions._Cart_id.Length; i++)
				{
                    var cart = _context.Carts.Find(Functions._Cart_id[i]);
                    cart.quantity = (int)Functions._QuantityCart[i];
                    _context.SaveChanges();
				}
                return true;
			}
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Order order)
        {
            //return Ok(Functions._Cart_id);
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                bool isTrue = CreateOrderCart(order.id) && EditCart() ? true : false;
                if (isTrue) {
					Functions._Message = "Đặt hàng thành công!";
                    return Ok(new
                    {
                        next_page = "/",
                    });
                }
                return BadRequest(new
                {
                    order = order,
                    message = "Không đặt hàng thành công!",
                });
            }
            Functions._ErrorMessage = "Lỗi không thể đặt hàng!";
            return BadRequest();
        }
    }
}
//Sửa bản ghi của cart để phù hợp vs quantity đã chỉnh sửa khi thanh toán