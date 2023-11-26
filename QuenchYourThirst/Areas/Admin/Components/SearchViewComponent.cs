using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Areas.Admin.Components
{
    [ViewComponent(Name = "SearchView")]
    public class SearchViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public SearchViewComponent(DataContext context) { _context = context; }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("searchView"));
        }
    }
}
