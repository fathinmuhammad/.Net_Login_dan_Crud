using System;
using System.Collections.Generic;
using Test_FathinMuhammadFadhlullah.Services;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Utils;
using Test_FathinMuhammadFadhlullah.Repositories;
using Test_FathinMuhammadFadhlullah.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Test_FathinMuhammadFadhlullah.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UserGroupController : BaseController
    {
        private IUserGroupService repo;
        private IMenuRepository repoMenu;

        List<String> Scripts = new List<String>();
        CSS_REF oCSSRef = new CSS_REF();

        public UserGroupController(IUserGroupService repo, IMenuRepository repoMenu)
        {
            this.repo = repo;
            this.repoMenu = repoMenu;
        }


        // GET: Administration/UserGroup
        public ActionResult Index()
        {
            if (!repo.checkPermission("administration/usergroup", "R")) return Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/datatables.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/scripts/datatable.js");
            Scripts.Add("assets/global/plugins/datatables/datatables.min.js");
            Scripts.Add("assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js");
            Scripts.Add("assets/modules/js/listDatatables.js");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/usergroup";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            return View(repo.search(""));
        }


        [HttpGet]
        public ActionResult Add()
        {
            if (!repo.checkPermission("administration/usergroup", "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/usergroup";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            UserGroup oUG = new UserGroup();
            return View("UserGroupForm", oUG);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UserGroup oUserGroup)
        {
            if (!repo.checkPermission("administration/usergroup", "C")) return Redirect("/noauth");

            try
            {
                repo.add(oUserGroup);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Add");
            }
            TempData["Message"] = "User Group Created Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Edit(string code)
        {
            if (!repo.checkPermission("administration/usergroup", "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/usergroup";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            UserGroup oUG = null;

            try
            {
                oUG = repo.get(int.Parse(code));
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Index", "usergroup");
            }
            return View("UserGroupForm", oUG);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserGroup oUG)
        {
            if (!repo.checkPermission("administration/usergroup", "U")) return Redirect("/noauth");
            try
            {
                repo.update(oUG);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Edit", "usergroup", new { code = oUG.usergroup_id });
            }
            TempData["Message"] = "User Group Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Edit", "UserGroup", new { code = oUG.usergroup_id });

        }

        [HttpGet]
        public ActionResult Permission(int code)
        {
            if (!repo.checkPermission("administration/usergroup", "R")) return Redirect("/noauth");

            Scripts.Add("assets/modules/js/ugpermission.js");
            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/usergroup";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            UserGroup oUG = null;

            try
            {
                ViewBag.lsNav = repo.getNav();
                oUG = repo.get(code);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Index");
            }
            return View("UGPermission", oUG);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Permission(IFormCollection objSubmit)
        {
            if (!repo.checkPermission("administration/usergroup", "U")) return Redirect("/noauth");

            UserPermission oUGPermission = new UserPermission();
            try
            {
                int i = 0;
                while (!String.IsNullOrEmpty(objSubmit["permission[" + i + "].ugID"]))
                {
                    oUGPermission = repo.getBykey(int.Parse(objSubmit[String.Format("permission[{0}].ugID", i)]), int.Parse(objSubmit[String.Format("permission[{0}].menu_id", i)]));
					if (oUGPermission != null)
					{
						oUGPermission.create_perm = (!String.IsNullOrEmpty(objSubmit[String.Format("permission[{0}].create", i)])) ? int.Parse(objSubmit[String.Format("permission[{0}].create", i)]) : 0;
						oUGPermission.edit_perm = (!String.IsNullOrEmpty(objSubmit[String.Format("permission[{0}].edit", i)])) ? int.Parse(objSubmit[String.Format("permission[{0}].edit", i)]) : 0;
						oUGPermission.view_perm = (!String.IsNullOrEmpty(objSubmit[String.Format("permission[{0}].view", i)])) ? int.Parse(objSubmit[String.Format("permission[{0}].view", i)]) : 0;
						oUGPermission.delete_perm = (!String.IsNullOrEmpty(objSubmit[String.Format("permission[{0}].delete", i)])) ? int.Parse(objSubmit[String.Format("permission[{0}].delete", i)]) : 0;
						oUGPermission.cancel_perm = (!String.IsNullOrEmpty(objSubmit[String.Format("permission[{0}].cancel", i)])) ? int.Parse(objSubmit[String.Format("permission[{0}].cancel", i)]) : 0;
						repo.updatePer(oUGPermission);
					}
					i++;
				}
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Permission", new { code = int.Parse(objSubmit["usergroup_id"]) });
            }
            TempData["Message"] = "Permission Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Permission", new { code = int.Parse(objSubmit["usergroup_id"]) });
        }

        public ActionResult Delete(System.Int32 code)
        {
            if (!repo.checkPermission("administration/usergroup", "D")) return Redirect("/noauth");

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
            TempData["Message"] = "User Group Deleted Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
        }
    }
}