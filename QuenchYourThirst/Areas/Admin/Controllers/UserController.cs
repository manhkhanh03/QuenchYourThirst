using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuenchYourThirst.Areas.Admin.Models;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using QuenchYourThirst.Controllers;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly DataContext _context;
		public UserController(DataContext context) { _context = context; }
		public IActionResult Index()
		{
			//if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });
			var users = _context.AdminUsers.Select(u => new
            {
                id = u.id,
                login_name = u.login_name,
                role_id = u.role_id,
                role = _context.Roles.Where(r => r.id == u.role_id).Select(r => r.name).FirstOrDefault(),
                email = u.email,
                address = u.address,
                phone = u.phone,
                img_user = u.img_user,
                created_at = u.created_at,
            }).ToList();
			ViewData["actionName"] = "index";
			ViewData["controllerName"] = "user";

			var dropdown = new List<SelectListItem> {
				new SelectListItem()
                {
                    Text = "Tên người dùng",
                    Value = "1",
                },new SelectListItem()
                {
                    Text = "Id người dùng",
                    Value = "2",
                },new SelectListItem()
                {
                    Text = "Email",
                    Value = "3",
                },new SelectListItem()
                {
                    Text = "Số điện thoại",
                    Value = "4",
                },
            };
			
			ViewBag.SearchView = new
			{
				form = "#tbody",
				dropdown = dropdown,
            };
			return View(users);
		}
        // đẩy dữ liệu sang searchview - hàm sẽ được viết ở mỗi file riêng 
        public IActionResult Create()
        {
            if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });
            var roles = _context.Roles.ToList();
            roles.Insert(0, new Role()
            {
                id = 0,
                name = "<------------------ Chọn ------------------>"
            });
            ViewBag.Roles = roles;
            ViewData["actionName"] = "create";
            ViewData["controllerName"] = "user";
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminUser user)
        {
            var register = new RegisterController(_context);
            register.Index(user);
            return RedirectToAction("index", "user");
        }

        public IActionResult Edit(long id)
        {
            if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });
            if (id == 0) return Redirect("/not-found");
			var user = _context.AdminUsers.Find(id);
			if (user == null) return Redirect("/not-found");
			var roles = _context.Roles.ToList();
			roles.Insert(0, new Role()
			{
				id = 0,
				name = "<------------------ Chọn ------------------>"
			});
			ViewBag.Roles = roles;
            ViewData["actionName"] = "index";
            ViewData["controllerName"] = "user";
            return View(user);
		}

		[HttpPost]
		public IActionResult Edit(AdminUser user)
		{
			if (!Functions.isAdmin()) return BadRequest();
            var currentUser = _context.AdminUsers.Find(user.id);
			currentUser.role_id = user.role_id;
			_context.SaveChanges();
			Functions._Message = "Cập nhật thông tin người dùng thành công!";
			return RedirectToAction("index", "user");
		}
		
		public IActionResult Delete(long? id)
		{
            if (id == 0 || id == null) return BadRequest();
            var user = _context.AdminUsers.Find(id);
            if (user == null) return BadRequest();

            var roles = _context.Roles.ToList();
            roles.Insert(0, new Role()
            {
                id = 0,
                name = "<------------------ Chọn ------------------>"
            });
            ViewBag.Roles = roles;
            ViewData["actionName"] = "index";
            ViewData["controllerName"] = "user";
            return View(user);
        }

		[HttpPost]
		public IActionResult Delete(long id)
		{
			if (id == 0 || id == null) return BadRequest();
			var user = _context.AdminUsers.Find(id);
			if (user == null) return BadRequest();
			_context.AdminUsers.Remove(user);
			_context.SaveChanges();
			Functions._Message = "Xoá người dùng thành công!";
			return RedirectToAction("index", "user");
		}
	}
}
