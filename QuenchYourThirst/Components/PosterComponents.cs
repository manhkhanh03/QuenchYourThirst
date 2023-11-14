using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Components
{
	[ViewComponent(Name = "Poster")]
	public class PosterComponents : ViewComponent
	{
		private readonly DataContext _context;
		public PosterComponents (DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listoPost = (from p in _context.Posters
							 where (p.PotID == 1)
							 select p).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listoPost));
		}
	}
}
