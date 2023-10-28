using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Components
{
	[ViewComponent(Name ="Postss")]
	public class PostssComponents :ViewComponent
	{
		private readonly DataContext _context;
		public PostssComponents(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofPost = (from p in _context.Postss
							  where (p.IsActive== true) && (p.Status == 1)
							  select p).Take(3).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
		}
	}
}
