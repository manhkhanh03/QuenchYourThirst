using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name = "Category")]
    public class CategoryComponents : ViewComponent
    {
        private readonly DataContext _context;
        public CategoryComponents (DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofCategory = (from m in _context.Categorys
                                  select m).ToList();
            return await Task.FromResult((IViewComponentResult) View ("default", listofCategory));
        }
    }
}
