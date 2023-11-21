using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Controllers
{
	public class OrderController : Controller
	{
		private readonly DataContext _context;
		public OrderController(DataContext context) { 
			_context = context;
		}
		public IActionResult Index()
		{
            if (!Functions.isLogin()) return RedirectToAction("index", "login");
            var userId = Functions._Id;
            var order = (from item in _context.Carts
						 join oc in _context.OrderCarts on item.id equals oc.cart_id
						 join o in _context.Orders on oc.order_id equals o.id
						 join psf in _context.ProductSizeFlavors on item.product_size_flavor_id equals psf.id
                         join p in _context.Products on psf.product_id equals p.id
                         where o.customer_id == userId && item.status_cart_id == 2
                         select new
                         {
                             order = o,
                             cart = item,
                             flavor = (from f in _context.Flavors where f.id == psf.flavor_id select f.name).FirstOrDefault(),
                             size = (from s in _context.Sizes where s.id == psf.size_id select s.name).FirstOrDefault(),
                             image = (from pi in _context.ProductImages where p.id == pi.product_id select pi.url).FirstOrDefault(),
                             product = p,
                         }).ToList();
            //return Ok( order );
            //var order = (from o in _context.Orders
            //                 join u in _context.AdminUsers on o.customer_id equals u.id
            //                 join oc in _context.OrderCarts on o.id equals oc.order_id
            //                 join c in _context.Carts on oc.cart_id equals c.id
            //                 join psf in _context.ProductSizeFlavors on c.product_size_flavor_id equals psf.id
            //                 join p in _context.Products on psf.product_id equals p.id
            //                 where o.customer_id == userId && c.status_cart_id == 2
            //                 select new
            //                 {
            //                     order = o,
            //                     flavor = (from f in _context.Flavors where f.id == psf.flavor_id select f.name).FirstOrDefault(),
            //                     size = (from s in _context.Sizes where s.id == psf.size_id select s.name).FirstOrDefault(),
            //                     image = (from pi in _context.ProductImages where p.id == pi.product_id select pi.url).FirstOrDefault(),
            //                     product = p,
            //                 }
            //                 ).ToList();
            var status = _context.StatusOrders.ToList();
            status.Insert(0, new StatusOrder()
            {
                id = 0,
                name = "Tất cả",
            });
            ViewBag.StatusOrder = status;
            return View(order);
		}

        public IActionResult Cancel(long id)
        {
            if (id == 0 || id == null) return Redirect("/not-found");
            var order = _context.Orders.Find(id);
            if (order == null) return Redirect("/not-found");
            order.status_order_id = 4;
            _context.SaveChanges();
            Functions._Message = "Yêu cầu huỷ thành công!";
            return RedirectToAction("index", "order");
        }
	}
}
