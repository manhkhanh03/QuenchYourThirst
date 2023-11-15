using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name ="Deal_of_the_day")]
    public class Deal_of_the_dayComponents :ViewComponent
    {
        private readonly DataContext _context;
        public Deal_of_the_dayComponents(DataContext context )
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofDeal = (from p in _context.Deal_of_the_day
                              select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofDeal));
        }
    }
}
