using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name ="Services")] 
    
    public class ServicesComponents :ViewComponent
    {
        private readonly DataContext _context;
        public ServicesComponents (DataContext context)
        {
            _context= context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listoServices = ( from p in _context.Services
                              select p).ToList();                   
            return await Task.FromResult((IViewComponentResult)View("Default", listoServices));
        }
    }
}
