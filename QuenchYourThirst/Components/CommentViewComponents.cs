using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.Collections.Generic;

namespace QuenchYourThirst.Components
{
	[ViewComponent(Name = "CommentView")]
	public class CommentViewComponents : ViewComponent
	{
		private readonly DataContext _context;
		public  CommentViewComponents (DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var category = ViewData["category"];
			var productId = ViewData["next"];
			var comments = _context.Comments
				.Where(c => c.product_id == Convert.ToInt64(productId) && c.parent_id == null)
				.Select(c => new
				{
					comment = c,
					user = _context.AdminUsers.Where(u => u.id == c.user_id).FirstOrDefault(),
					feedback = _context.Comments.Where(f => f.parent_id == c.id).FirstOrDefault(),
				}).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", comments));
		}
	}
}
