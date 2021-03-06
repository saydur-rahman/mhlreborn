﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StairEstate.Service;

namespace StaitEstate.View.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IMenuService _menuService;

        public DashBoardController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: DashBoard
        public ActionResult Index()
        {
            var login = UserSession.GetUserFromSession();
            if (login != null)
            {
                var menus = _menuService.GetSysMenus().OrderBy(m => m.menu_presidence);
                if (menus != null)
                    ViewBag.Menus = menus;
                else
                    ViewBag.Menus = null;
                return View();
            }
            
            return RedirectToAction("Login", "Home");
        }
    }
}