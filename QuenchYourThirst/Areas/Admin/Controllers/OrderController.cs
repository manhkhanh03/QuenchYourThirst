using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly DataContext _context;
        public OrderController(DataContext context) { _context = context; }
        public async Task<Dictionary<string, object>> GetOrders(int statusOrder = 0)
        {
            var orders = await (from o in _context.Orders
                          orderby o.created_at ascending
                          where o.status_order_id == statusOrder || statusOrder == 0
                          select new
                          {
                              o = o,
                              customer = _context.AdminUsers.Where(u => u.id == o.customer_id).FirstOrDefault(),
                              products = _context.Products
                                    .Where(p => _context.ProductSizeFlavors
                                        .Where(psf => _context.Carts
                                            .Where(c => _context.OrderCarts
                                                .Where(oc => oc.order_id == o.id)
                                                .Select(oc => oc.cart_id)
                                                .Contains(c.id))
                                            .Select(c => c.product_size_flavor_id).Contains(psf.id))
                                        .Select(psf => psf.product_id).Contains(p.id))
                                    .Select(p => new
                                    {
                                        product = p,
                                        image = _context.ProductImages.Where(i => i.product_id == p.id).Select(i => i.url).FirstOrDefault(),
                                        quantity = _context.Carts
                                            .Where(c => _context.ProductSizeFlavors
                                                .Where(psf => psf.product_id == p.id)
                                                .Select(psf => psf.id).Contains(c.product_size_flavor_id))
                                            .Select(c => c.quantity).FirstOrDefault(),
                                        flavor = _context.Flavors
                                            .Where(f => f.id == _context.ProductSizeFlavors
                                                .Where(psf => psf.product_id == p.id).Select(psf => psf.flavor_id).FirstOrDefault()).Select(f => f.name).FirstOrDefault()
                                    }).ToList(),
                              status = _context.StatusOrders.Where(so => so.id == o.status_order_id).FirstOrDefault(),
                          }).ToListAsync();
            return new Dictionary<string, object> {
                {"orders", orders },
            };
        }
        public async Task<IActionResult> Index()
        {
            var orders = await GetOrders();
            var dropdown = new List<SelectListItem> {
                new SelectListItem()
                {
                    Text = "Khách hàng",
                    Value = "2",
                },new SelectListItem()
                {
                    Text = "Hương vị",
                    Value = "3",
                },new SelectListItem()
                {
                    Text = "Số lượng",
                    Value = "4",
                },new SelectListItem()
                {
                    Text = "Trạng thái",
                    Value = "5",
                },
            };

            ViewBag.SearchView = new
            {
                form = "#tbody",
                dropdown = dropdown,
            };

            ViewData["actionName"] = "index";
            ViewData["controllerName"] = "order";
            return View(orders["orders"]);
        }

        public async Task<IActionResult> Cancel()
        {
            var orders = await GetOrders(4);
            var dropdown = new List<SelectListItem> {
                new SelectListItem()
                {
                    Text = "Khách hàng",
                    Value = "2",
                },new SelectListItem()
                {
                    Text = "Hương vị",
                    Value = "3",
                },new SelectListItem()
                {
                    Text = "Số lượng",
                    Value = "4",
                },new SelectListItem()
                {
                    Text = "Trạng thái",
                    Value = "5",
                },
            };

            ViewBag.SearchView = new
            {
                form = "#tbody",
                dropdown = dropdown,
            };

            ViewData["actionName"] = "cancel";
            ViewData["controllerName"] = "order";
            return View(orders["orders"]);
        }

		public async Task<IActionResult> Auth()
		{
			var orders = await GetOrders(6);
			var dropdown = new List<SelectListItem> {
				new SelectListItem()
				{
					Text = "Khách hàng",
					Value = "2",
				},new SelectListItem()
				{
					Text = "Hương vị",
					Value = "3",
				},new SelectListItem()
				{
					Text = "Số lượng",
					Value = "4",
				},new SelectListItem()
				{
					Text = "Trạng thái",
					Value = "5",
				},
			};

			ViewBag.SearchView = new
			{
				form = "#tbody",
				dropdown = dropdown,
			};

			ViewData["actionName"] = "auth";
			ViewData["controllerName"] = "order";
			return View(orders["orders"]);
		}

		[HttpPost]
        public IActionResult Edit(Order order)
        {
            if (order.id == 0) return BadRequest();
            var _order = _context.Orders.Find(order.id);
            if (_order == null) return BadRequest();

            _order.status_order_id = order.status_order_id;
            _context.SaveChanges();
            Functions._Message = "Đơn hàng đã được thay đổi trạng thái!";
            return RedirectToAction("index", "order");
        }
    }
}



//Sửa phần order ở bên ngoài người dùng khi  bấm vào button, kiểm tra trường hợp nếu không có đơn hàng trong phần cart