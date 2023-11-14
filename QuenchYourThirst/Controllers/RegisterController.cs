using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using QuenchYourThirst.Areas.Admin.Models;

namespace QuenchYourThirst.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] AdminUser user)
        {
            //return Ok(user);
            if (user == null) return BadRequest(user);
            var checkEmail = _context.AdminUsers.Where(u => user.email == u.email).FirstOrDefault();
            var checkLoginName = _context.AdminUsers.Where(u => u.login_name == user.login_name).FirstOrDefault();
            if (checkEmail != null || checkLoginName != null)
            {
                Functions._ErrorMessage = checkLoginName != null ? "login_name" : "email";
                return BadRequest(new
                {
                    message = (Functions._ErrorMessage == "login_name" ? "Tên đăng nhập" : Functions._ErrorMessage) + " đã có người sử dụng!",
                    e = Functions._ErrorMessage,
                });
            }

            Functions._ErrorMessage = string.Empty;
            user.password = Functions.MD5Password(user.password);
            _context.AdminUsers.Add(user);
            _context.SaveChanges();
            return Ok(new
                {
                    next_page = "/login",
                });
        }
    }
}
