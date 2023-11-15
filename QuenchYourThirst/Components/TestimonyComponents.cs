using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name = "Testimony")]
    public class TestimonyComponents : ViewComponent
    {
        private readonly DataContext _context;
        public TestimonyComponents (DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofTestimony = (from p in _context.Testimony
                                   select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofTestimony));
        }
    }
}
