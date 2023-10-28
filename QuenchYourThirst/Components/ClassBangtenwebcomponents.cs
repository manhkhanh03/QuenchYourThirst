using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using Microsoft.EntityFrameworkCore;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name ="Tenweb")]
    public class ClassBangtenwebcomponents :ViewComponent  
    {
        private  readonly DataContext _context;
        public ClassBangtenwebcomponents(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Bangtenwebs
                              where (m.Id == 1 ) 
                              select m). Take(1).ToList();
            return await Task.FromResult((IViewComponentResult) View ("Default", listofMenu));
        }
    }
}
