using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = ""}); 
			ViewData["actionName"] = "index";
			ViewData["controllerName"] = "home";
			return View();
		}
	}
}
