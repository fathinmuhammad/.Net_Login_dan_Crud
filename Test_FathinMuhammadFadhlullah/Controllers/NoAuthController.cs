using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_FathinMuhammadFadhlullah.Models;
using Test_FathinMuhammadFadhlullah.Repositories;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test_FathinMuhammadFadhlullah.Controllers
{
    public class NoAuthController : Controller
    {
        List<String> Scripts = new List<String>();
        CSS_REF oCSSRef = new CSS_REF();
        protected IMenuRepository repo;

        public NoAuthController(IMenuRepository repo)
        {
            this.repo = repo;
        }

        // GET: NoAuth
        [SessionAuthorize]
        public ActionResult Index()
        {
            oCSSRef.addByHtml("<link href=\"/assets/pages/css/error.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
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

        [AllowAnonymous]
        public IActionResult Error(string id = "")
        {
            switch (id)
            {
                case "403":
                    return PartialView("AccessDenied");
                case "404":
                    return PartialView("PageNotFound");
                default:
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [AllowAnonymous]
        public IActionResult PageNotFound()
        {
            Response.StatusCode = 404;

            return View();
        }

        [AllowAnonymous]
        public IActionResult AntiForgery()
        {
            return View();
        }
    }

}