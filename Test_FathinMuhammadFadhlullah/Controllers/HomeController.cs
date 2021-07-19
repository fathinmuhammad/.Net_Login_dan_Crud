using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test_FathinMuhammadFadhlullah.Models;
using Test_FathinMuhammadFadhlullah.Repositories;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Test_FathinMuhammadFadhlullah.DTO;

namespace Test_FathinMuhammadFadhlullah.Controllers
{
    public class HomeController : BaseController
    {
        protected IMenuRepository repo;

        public HomeController(IMenuRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<String> Scripts = new List<String>();
            CSS_REF oCSSRef = new CSS_REF();

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "home";
            TempData["menu_tree"] = repo.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repo.getBreadcrumb((string)TempData["current_menu"]);
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
