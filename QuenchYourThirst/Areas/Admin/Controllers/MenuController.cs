﻿using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuenchYourThirst.Models;
using QuenchYourThirst.Utilities;

namespace QuenchYourThirst.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;
        public MenuController(DataContext context) { _context = context; }
        public IActionResult Index()
        {
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

			var menus = _context.Menus.OrderBy(m => m.id).ToList();
            ViewData["actionName"] = "";
            ViewData["controllerName"] = "menu";
            var dropdown = new List<SelectListItem> {
                new SelectListItem()
                {
                    Text = "Tiêu đề",
                    Value = "1",
                },new SelectListItem()
                {
                    Text = "Id menu",
                    Value = "2",
                },new SelectListItem()
                {
                    Text = "Vị trí",
                    Value = "3",
                },new SelectListItem()
                {
                    Text = "Đường dẫn",
                    Value = "4",
                },
            };

            ViewBag.SearchView = new
            {
                form = "#tbody",
                dropdown = dropdown,
            };
            return View(menus);
        }

        public IActionResult Create()
		{
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

            ViewBag.Menus = Menus();
            ViewData["actionName"] = "create";
            ViewData["controllerName"] = "menu";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Menu menu)
        {
            if(ModelState.IsValid)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                Functions._Message = "Thêm menu thành công!";
                return Redirect("index");
            }
            return BadRequest(menu);
        }
        private List<SelectListItem> Menus()
        {
            var mns = _context.Menus.Select(m => new SelectListItem()
                        {
                            Text = m.menuName,
                            Value = m.id.ToString(),
                        }).ToList();
            mns.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "----- Chọn -----",
            });
            return mns;
        }

        public IActionResult Edit(long id)
        {
            if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

            var menu = _context.Menus.FirstOrDefault(m => m.id == id);
            if (menu == null || id == 0 || id == null) { return Redirect("/not-found"); }

            ViewData["actionName"] = "edit";
            ViewData["controllerName"] = "menu";
            ViewBag.Menus = Menus();
            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menus.Update(mn);
                _context.SaveChanges();
                Functions._Message = "Sửa menu thành công!";
                return RedirectToAction("index", "menu");
            }
            return BadRequest(mn);
        }

        [HttpGet]
        public IActionResult Delete(long? id = 0)
		{
			if (!Functions.isAdmin()) return RedirectToAction("index", "home", new { area = "" });

			var menu = _context.Menus.Find((int)id);
			if (menu == null) { return Redirect("/not-found"); }
			ViewData["actionName"] = "delete";
			ViewData["controllerName"] = "menu";
			return View(menu);
		}

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var menu = _context.Menus.Find((int)id);
            if (menu == null) { return BadRequest(menu); }
            _context.Menus.Remove(menu);
            _context.SaveChanges();
            Functions._Message = "Xoá menu thành công!";
            return Redirect("/admin/menu/index");
        }
    }
}
