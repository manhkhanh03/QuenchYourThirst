using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Areas.Admin.Models;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.Net;

namespace QuenchYourThirst.Controllers
{
	public class ProfileController : Controller
	{
		private readonly DataContext _context;
		public ProfileController(DataContext context) { _context = context; }
		public IActionResult Index()
		{
			if (!Functions.isLogin()) return RedirectToAction("index", "login");
			var user = _context.AdminUsers.Find(Functions._Id);
			if (user == null) return RedirectToAction("index", "login");
			return View(user);
		}

		[HttpPost]
		public IActionResult Edit (AdminUser user)
		{
			if (ModelState.IsValid)
			{
				_context.AdminUsers.Update(user);
				_context.SaveChanges();
				Functions._Email = user.email;
				Functions._Address = user.address;
				Functions._Phone = user.phone;
				Functions._Image = user.img_user;
				Functions._Message = "Thay đổi thông tin liên hệ thành công!";
				return RedirectToAction("index", "profile");
			}
			return BadRequest(user);
		}

		[HttpPost]
		public IActionResult EditPassword([FromBody] Dictionary<string, string> request)
		{
			//return Ok(request);
			var oldPassword = Functions.MD5Password((request["old-password"]).ToString());
			var user = _context.AdminUsers.Find(Functions._Id);

			if (user.password != oldPassword) return BadRequest(new { message = "Mật khẩu cũ không đúng!", err = "#old-password"});
            if (user != null) 
			{
				user.password = Functions.MD5Password(request["password"].ToString()); ;
				_context.AdminUsers.Update(user);
				_context.SaveChanges();
				return Ok(new {message = "Thay đổi mật khẩu thành công!"});
			}
			return BadRequest("Không tìm thấy người dùng!");
		}

	}
}
