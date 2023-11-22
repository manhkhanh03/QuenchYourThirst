using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name = "Category1")]
    public class Category1Components: ViewComponent
    {
        private readonly DataContext _context;
        public Category1Components(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofCategory1 = (from m in _context.Category1
                                  select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("default", listofCategory1));
        }


    }

}

