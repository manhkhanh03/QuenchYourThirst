using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using System.Runtime.InteropServices;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name ="MenuView")]
    public class ClassMenuViewComponent : ViewComponent
    {
        private  readonly DataContext _context;
        public ClassMenuViewComponent (DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _context.Menus
                              where(m.IsActive ==  true) && (m.Position==1)
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View ("Default", listofMenu));
        }
    }
}
