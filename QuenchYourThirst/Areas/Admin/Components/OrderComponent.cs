using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Areas.Admin.Components
{
	[ViewComponent(Name = "OrderView")]
	public class OrderComponent : ViewComponent
	{
		private readonly DataContext _context;
		public OrderComponent(DataContext context) { _context = context; }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return await Task.FromResult((IViewComponentResult)View("orderView"));
		}
    }
}
