using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuenchYourThirst.Areas.Admin.Models;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace QuenchYourThirst.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context) { _context = context; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] AdminUser user)
        {
            if (user == null) return BadRequest(user);

            string pw = Functions.MD5Password(user.password);

            var check = _context.AdminUsers.Where(u => (u.password == pw) && (u.email == user.email)).FirstOrDefault();

            if (check == null)
            {
                Functions._Message = "Tên đăng nhập hoặc mật khẩu không hợp lệ!";
                return BadRequest(new
                {
                    message = Functions._Message,
                });
                //return RedirectToAction("index", "index");
            }

			Functions._Message = string.Empty;
            Functions._LoginName = check.login_name;
            Functions._UserName = check.user_name;
            Functions._RoleId = check.role_id;
            Functions._Address = check.address;
            Functions._Phone = check.phone;
            Functions._Email = check.email;
            Functions._Image = check.img_user;
            Functions._Id = check.id;
            Functions._Created_at = check.created_at.ToString();
            return Ok(new
            {
                next_page = "/home",
            });
        }
    }
}
