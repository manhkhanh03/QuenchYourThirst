using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.Collections.Generic;

namespace QuenchYourThirst.Components
{
	[ViewComponent(Name = "RelatedProductView")]
	public class RelatedProductViewComponents : ViewComponent
	{
		private readonly DataContext _context;
		public  RelatedProductViewComponents (DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var category = ViewData["category"];
			var next = ViewData["next"];
			var products = (from p in _context.Products
							join psf in _context.ProductSizeFlavors on p.id equals psf.product_id into psfGroup
							join img in _context.ProductImages on p.id equals img.product_id
							where p.status_product_id == 1
							where p.product_category_id == Convert.ToInt64(category)
							select new
							{
								prices = psfGroup.Select(psf => psf.price).OrderBy(psf => psf).ToList(),
								product = p,
								img = img,
							}).Skip(Convert.ToInt32(next)).Take(4).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", products));
		}
	}
}
