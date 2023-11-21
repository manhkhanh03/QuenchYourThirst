using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Components
{
	[ViewComponent(Name ="footer")]

	public class footerComponents: ViewComponent
	{
		private readonly DataContext _context;
		public footerComponents (DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listtoffooter = (from p in _context.footer
								 select p).ToList();
			return await Task.FromResult((IViewComponentResult) View ("Default" , listtoffooter));
		}
	
	}
}
