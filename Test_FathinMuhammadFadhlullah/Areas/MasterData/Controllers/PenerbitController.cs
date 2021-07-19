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

namespace Test_FathinMuhammadFadhlullah.Areas.MasterData.Controllers
{
    [Area("MasterData")]
    public class PenerbitController : Controller
    {
        private IPenerbitRepository repo;
        private IMenuRepository repoMenu;
        private IUserGroupService repoUG;

        List<String> Scripts = new List<String>();
        CSS_REF oCSSRef = new CSS_REF();

        public PenerbitController(IPenerbitRepository repo, IMenuRepository repoMenu, IUserGroupService repoUG)
        {
            this.repo = repo;
            this.repoMenu = repoMenu;
            this.repoUG = repoUG;
        }

        string SLUG = "masterdata/penerbit";
        public ActionResult Index()
        {
            if (!repoUG.checkPermission(SLUG, "R")) return Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/datatables.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/scripts/datatable.js");
            Scripts.Add("assets/global/plugins/datatables/datatables.min.js");
            Scripts.Add("assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js");
            Scripts.Add("assets/modules/js/listDatatables.js");
            Scripts.Add("assets/modules/js/dtTableServerSide.js");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = SLUG;
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            return View(new List<Penerbit>());
        }

        public ActionResult IndexSearch(string draw, IEnumerable<Dictionary<string, string>> columns, IEnumerable<Dictionary<string, string>> order, int start, int length, string search, string _)
        {
            IEnumerable<Dictionary<string, string>> param = columns;
            var serch = Request.Query["search[value]"];
            AES aes = new AES();
            List<string[]> lsParam = new List<string[]>();

            if (Request.Query["nama"].ToString() != "") lsParam.Add(new string[] { "nama", Request.Query["nama"].ToString() }); ViewBag.nama = Request.Query["nama"].ToString();
            if (Request.Query["alamat"].ToString() != "") lsParam.Add(new string[] { "alamat", Request.Query["alamat"].ToString() }); ViewBag.alamat = Request.Query["alamat"].ToString();

            foreach (var o in order)
            {
                o["column"] = "1";
            }

            try
            {
                PenerbitDTO dt = new PenerbitDTO();

                List<string> lsColumns = new List<string>();

                lsColumns.Add("no");
                lsColumns.Add("nama");
                lsColumns.Add("alamat");
                lsColumns.Add("action");

                Utils.Datatables.PenerbitdtTbl summarydt = new Utils.Datatables.PenerbitdtTbl(repo);
                dt = summarydt.simple(start, length, order, serch, columns, lsColumns, lsParam);

                List<List<string>> summarys = new List<List<string>>();
                int i = start + 1;

                foreach (var d in dt.data)
                {
                    List<string> summary = new List<string>();

                    string action = "";
                    action = "<a href=\"" + Url.Action("Edit", "Penerbit", new { code = aes.Encrypt("PRT", d.penerbit_id.ToString()) }) + "\" class=\"icon huge\" title=\"Details User\"><i class=\"fa fa-pencil\"></i></a>&nbsp;";
                    action += "<a href=\"" + Url.Action("Delete", "Penerbit", new { code = aes.Encrypt("PRT", d.penerbit_id.ToString()) }) + "\" class=\"icon huge\" title=\"Delete User\"><i class=\"fa fa-trash-o\" onclick=\"return confirm('are you sure ?')\"></i></a>&nbsp;";

                    summary.Add(i.ToString());
                    summary.Add(d.nama);
                    summary.Add(d.alamat);
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

        [HttpGet]
        public ActionResult Add()
        {
            if (!repoUG.checkPermission(SLUG, "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = SLUG;
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            Penerbit oPenerbit = new Penerbit();
            return View("PenerbitForm", oPenerbit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Penerbit oPenerbit)
        {
            if (!repoUG.checkPermission(SLUG, "C")) return Redirect("/noauth");

            try
            {
                repo.add(oPenerbit);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Add");
            }
            TempData["Message"] = "Penerbit Created Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(string code)
        {
            if (!repoUG.checkPermission(SLUG, "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = SLUG;
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            AES aes = new AES();
            var id = aes.Decrypt("PRT", code);

            return View("PenerbitForm", repo.get(int.Parse(id)));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Penerbit oPenerbit)
        {
            AES aes = new AES();

            if (!repoUG.checkPermission(SLUG, "U")) return Redirect("/noauth");

            try
            {
                User user = new User();
                var id = Request.Form["penerbit_id"];
                oPenerbit.penerbit_id = int.Parse(id);
                repo.update(oPenerbit);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Edit", "Penerbit", new { code = aes.Encrypt("PRT", Request.Form["penerbit_id"]) });
            }
            TempData["Message"] = "Penerbit Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Edit", "Penerbit", new { code = aes.Encrypt("PRT", Request.Form["penerbit_id"]) });

        }
        public ActionResult Delete(string code)
        {
            if (!repoUG.checkPermission(SLUG, "D")) return Redirect("/noauth");
            if (!string.IsNullOrEmpty(code))
            {
                try
                {
                    AES aes = new AES();
                    var id = aes.Decrypt("PRT", code);

                    repo.del(int.Parse(id));
                }
                catch (Exception e)
                {
                    TempData["Message"] = e.Message;
                    TempData["Error"] = "Error";
                    return RedirectToAction("Index");
                }
            }
            TempData["Message"] = "Penerbit Deleted Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
        }
    }
}
