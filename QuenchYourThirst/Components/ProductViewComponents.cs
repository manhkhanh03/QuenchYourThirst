using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;
using System.Collections.Generic;

namespace QuenchYourThirst.Components
{
	[ViewComponent(Name = "ProductView")]
	public class ProductViewComponents: ViewComponent
	{
		private readonly DataContext _context;
		public  ProductViewComponents (DataContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var products = (from p in _context.Products
							join psf in _context.ProductSizeFlavors on p.id equals psf.product_id into psfGroup
							join img in _context.ProductImages on p.id equals img.product_id
							where p.status_product_id == 1
							select new
							{
								prices = psfGroup.Select(psf => psf.price).OrderBy(psf => psf).ToList(),
								products = p,
								img = img,
							}).Skip(1).Take(8).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", products));
		}
	}
}
