using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_FathinMuhammadFadhlullah.Services;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Utils;
using Test_FathinMuhammadFadhlullah.Repositories;
using Microsoft.AspNetCore.Mvc;
using Test_FathinMuhammadFadhlullah.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Test_FathinMuhammadFadhlullah.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class MenuController : Controller
    {
        private IMenuRepository repo;
        private IUserGroupService repoUG;

        List<String> Scripts = new List<String>();
        CSS_REF oCSSRef = new CSS_REF();

        public MenuController(IMenuRepository repo, IUserGroupService repoUG)
        {
            this.repo = repo;
            this.repoUG = repoUG;
        }

        // GET: Administration/Menu 
        public ActionResult Index()
        {
            if (!repoUG.checkPermission("administration/menu", "R")) return Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/datatables.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/scripts/datatable.js");
            Scripts.Add("assets/global/plugins/datatables/datatables.min.js");
            Scripts.Add("assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js");
            Scripts.Add("assets/modules/js/listDatatables.js");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/menu";
            TempData["menu_tree"] = repo.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repo.getBreadcrumb((string)TempData["current_menu"]);

            return View(repo.search(""));
        }
        [HttpGet]
        public ActionResult Add()
        {
            if (!repoUG.checkPermission("administration/menu", "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/menu";
            TempData["menu_tree"] = repo.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repo.getBreadcrumb((string)TempData["current_menu"]);
            ViewBag.listParent = repo.search("").OrderBy(x => x.menu_title);

            return View("MenuForm", new Menu());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Menu oMenu)
        {
            if (!repoUG.checkPermission("administration/menu", "C")) return Redirect("/noauth");

            try
            {
                repo.add(oMenu);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Add");
            }
            TempData["Message"] = "Menu Created Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(string code)
        {
            if (!repoUG.checkPermission("administration/menu", "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/menu";
            TempData["menu_tree"] = repo.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repo.getBreadcrumb((string)TempData["current_menu"]);
            ViewBag.listParent = repo.search("").OrderBy(x => x.menu_title);

            Menu oMenu = repo.get(int.Parse(code));
            return View("MenuForm", oMenu);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu oMenu)
        {
            if (!repoUG.checkPermission("administration/menu", "U")) return Redirect("/noauth");

            try
            {
                repo.update(oMenu);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Edit", "Menu", new { code = oMenu.menu_id });
            }
            TempData["Message"] = "Menu Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Edit", "Menu", new { code = oMenu.menu_id });

        }

        public ActionResult Delete(System.Int32 code)
        {
            if (!repoUG.checkPermission("administration/menu", "D")) return Redirect("/noauth");

            if (code >= 0)
            {
                try
                {
                    repo.del(code);
                }
                catch (Exception e)
                {
                    TempData["Message"] = e.Message;
                    TempData["Error"] = "Error";
                    return RedirectToAction("Index");
                }
            }
            TempData["Message"] = "Menu Deleted Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Tree()
        {
            if (!repoUG.checkPermission("administration/menu", "R")) Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/jquery-nestable/jquery.nestable.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/plugins/jquery-nestable/jquery.nestable.js");
            Scripts.Add("assets/pages/scripts/ui-nestable.min.js");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/menu/tree";
            TempData["menu_tree"] = repo.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repo.getBreadcrumb((string)TempData["current_menu"]);
            TempData["nested_menu_tree"] = repo.getNestedMenuTree();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveTree(String sMenuTree)
        {
            if (!repoUG.checkPermission("administration/menu", "U")) Redirect("/noauth");
            try
            {
                string jsonText = Request.Form["nestable_list_1_output"];
                List<MenuTree> oJSON_Menus = new List<MenuTree>();
                oJSON_Menus = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuTree>>(jsonText);
                repo.update(oJSON_Menus, "0");
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Tree");
            }

            TempData["Message"] = "Menu Tree Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Tree");
        }
    }
}