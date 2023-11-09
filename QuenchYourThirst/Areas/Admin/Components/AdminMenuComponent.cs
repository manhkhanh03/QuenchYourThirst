using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Areas.Admin.Components
{
	[ViewComponent(Name = "AdminMenu")]
	public class AdminMenuComponent : ViewComponent
	{
		private readonly DataContext _context;
		public AdminMenuComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync ()
		{
			var menus = _context.AdminMenus.Where(m => m.isActive == true).ToList();
			return await Task.FromResult((IViewComponentResult)View("adminMenu", menus));
		}
	}
}
