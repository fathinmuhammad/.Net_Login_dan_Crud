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
using Microsoft.AspNetCore.Http;
using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using Newtonsoft.Json;

namespace Test_FathinMuhammadFadhlullah.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UserController : BaseController
    {
        private IUserService repo;
        private IMenuRepository repoMenu;
        private IUserGroupService repoUG;
        private IUserRepository usrRepo;

        List<String> Scripts = new List<String>();
        CSS_REF oCSSRef = new CSS_REF();

        public UserController(IUserService repo, IMenuRepository repoMenu, IUserGroupService repoUG, IUserRepository usrRepo)
        {
            this.repo = repo;
            this.repoMenu = repoMenu;
            this.repoUG = repoUG;
            this.usrRepo = usrRepo;
        }

        // GET: administration/User
        public IActionResult Index()
        {
            if (!repoUG.checkPermission("administration/user", "R")) return Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/datatables.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/scripts/datatable.js");
            Scripts.Add("assets/global/plugins/datatables/datatables.min.js");
            Scripts.Add("assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js");
            Scripts.Add("assets/modules/js/listDatatables.js");
            Scripts.Add("assets/modules/js/dtTableServerSide.js");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/user";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            return View(new List<User>());
        }

        public ActionResult IndexSearch(string draw, IEnumerable<Dictionary<string, string>> columns, IEnumerable<Dictionary<string, string>> order, int start, int length, string search, string _)
        {
            IEnumerable<Dictionary<string, string>> param = columns;
            var serch = Request.Query["search[value]"];
            AES aes = new AES();
            List<string[]> lsParam = new List<string[]>();

            if (Request.Query["username"].ToString() != "") lsParam.Add(new string[] { "username", Request.Query["username"].ToString() }); ViewBag.username = Request.Query["username"].ToString();
            if (Request.Query["fullname"].ToString() != "") lsParam.Add(new string[] { "fullname", Request.Query["fullname"].ToString() }); ViewBag.fullname = Request.Query["fullname"].ToString();

            foreach (var o in order)
            {
                o["column"] = "1";
            }

            try
            {
                UserDTO dt = new UserDTO();

                List<string> lsColumns = new List<string>();

                lsColumns.Add("no");
                lsColumns.Add("username");
                lsColumns.Add("fullname");
                lsColumns.Add("action");

                Utils.Datatables.UserdtTbl summarydt = new Utils.Datatables.UserdtTbl(usrRepo);
                dt = summarydt.simple(start, length, order, serch, columns, lsColumns, lsParam);

                List<List<string>> summarys = new List<List<string>>();
                int i = start + 1;

                foreach (var d in dt.data)
                {
                    List<string> summary = new List<string>();

                    string action = "";
                    action = "<a href=\"" + Url.Action("Edit", "User", new { code = aes.Encrypt("USR", d.user_id.ToString()) }) + "\" class=\"icon huge\" title=\"Details User\"><i class=\"fa fa-pencil\"></i></a>&nbsp;";
                    action += "<a href=\"" + Url.Action("Delete", "User", new { code = aes.Encrypt("USR", d.user_id.ToString()) }) + "\" class=\"icon huge\" title=\"Delete User\"><i class=\"fa fa-trash-o\" onclick=\"return confirm('are you sure ?')\"></i></a>&nbsp;";

                    summary.Add(i.ToString());
                    summary.Add(d.username);
                    summary.Add(d.fullname);
                    summary.Add(action);

                    summarys.Add(summary);
                    i++;
                }

                UserDTO.returnData models = new UserDTO.returnData();

                models.draw = int.Parse(draw);
                models.recordsTotal = dt.recordsTotal;
                models.recordsFiltered = dt.recordsFiltered;
                models.data = summarys;

                var json = JsonConvert.SerializeObject(models);

                return Json(models);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Index(IFormCollection objectForm)
        {
            if (!repoUG.checkPermission("administration/user", "R")) return Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/datatables.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/scripts/datatable.js");
            Scripts.Add("assets/global/plugins/datatables/datatables.min.js");
            Scripts.Add("assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js");
            Scripts.Add("assets/modules/js/listDatatables.js");
            Scripts.Add("assets/modules/js/TransInfo.js");
            Scripts.Add("assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js");

            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }

                List<string[]> lsParam = new List<string[]>();
                if (Request.Form["username"].ToString() != "") lsParam.Add(new string[] { "username", Request.Form["username"].ToString() }); ViewBag.username = Request.Form["username"].ToString();
                if (Request.Form["fullname"].ToString() != "") lsParam.Add(new string[] { "fullname", Request.Form["fullname"].ToString() }); ViewBag.fullname = Request.Form["fullname"].ToString();
                if (Request.Form["company_id"].ToString() != "") lsParam.Add(new string[] { "company_id", Request.Form["company_id"].ToString() }); ViewBag.company_id = Request.Form["company_id"].ToString();

                var data = repo.search(lsParam);

                TempData["css_controller"] = oCSSRef.toHtmlList();
                TempData["scripts_controller"] = Scripts;
                TempData["current_menu"] = "administration/user";
                TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
                TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

                return View("Index", data);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult Add()
        {
            if (!repoUG.checkPermission("administration/user", "R")) return Redirect("/noauth");

            Scripts.Add("assets/modules/js/user.js");
            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/user";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            List<SelectListItem> listUserActive = new List<SelectListItem>();
            listUserActive.Add(new SelectListItem { Value = "Y", Text = "Active" });
            listUserActive.Add(new SelectListItem { Value = "N", Text = "Not Active" });
            ViewBag.listUserActive = listUserActive;

            ViewBag.listUserGroup = repoUG.search("");

            User oUser = new Entities.User();
            return View("UserForm", oUser);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User oUser)
        {
            if (!repoUG.checkPermission("administration/user", "C")) return Redirect("/noauth");

            try
            {
                repo.add(oUser);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Add");
            }
            TempData["Message"] = "User Created Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(string code)
        {
            if (!repoUG.checkPermission("administration/user", "R")) return Redirect("/noauth");

            Scripts.Add("assets/modules/js/user.js");
            Scripts.Add("assets/modules/js/TransInfo.js");
            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = "administration/user";
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            List<SelectListItem> listUserActive = new List<SelectListItem>();
            listUserActive.Add(new SelectListItem { Value = "Y", Text = "Active" });
            listUserActive.Add(new SelectListItem { Value = "N", Text = "Not Active" });
            ViewBag.listUserActive = listUserActive;
            ViewBag.listUserGroup = repoUG.search("");

            AES aes = new AES();
            User user = new User();
            var id = aes.Decrypt("USR", code);

            return View("UserForm", repo.get(int.Parse(id)));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User oUser)
        {
            AES aes = new AES();

            if (!repoUG.checkPermission("administration/user", "U")) return Redirect("/noauth");

            try
            {                
                User user = new User();
                var id = Request.Form["user_id"];
                oUser.user_id = int.Parse(id);
                repo.update(oUser);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Edit", "User", new { code = aes.Encrypt("USR", Request.Form["user_id"]) });
            }
            TempData["Message"] = "User Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Edit", "User", new { code = aes.Encrypt("USR", Request.Form["user_id"]) });

        }
        public ActionResult Delete(string code)
        {
            if (!repoUG.checkPermission("administration/user", "D")) return Redirect("/noauth");
            if (!string.IsNullOrEmpty(code))
            {
                try
                {
                    AES aes = new AES();
                    User user = new User();
                    var id = aes.Decrypt("USR", code);

                    repo.del(int.Parse(id));
                }
                catch (Exception e)
                {
                    TempData["Message"] = e.Message;
                    TempData["Error"] = "Error";
                    return RedirectToAction("Index");
                }
            }
            TempData["Message"] = "User Deleted Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
        }
    }
}