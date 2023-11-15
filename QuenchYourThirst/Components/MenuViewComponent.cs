﻿using Microsoft.AspNetCore.Mvc;
using QuenchYourThirst.Models;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace QuenchYourThirst.Components
{
    [ViewComponent(Name ="MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private  readonly DataContext _context;
        public MenuViewComponent (DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()       
            {

            var listofMenu = (from m in _context.Menus
                              where(m.isActive ==  true) && (m.position==1)
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View ("Default", listofMenu));
        }
    }
}
