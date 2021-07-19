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
    public class BukuController : Controller
    {
        private IBukuRepository repo;
        private IPenerbitRepository repoPenerbit;
        private IMenuRepository repoMenu;
        private IUserGroupService repoUG;

        List<String> Scripts = new List<String>();
        CSS_REF oCSSRef = new CSS_REF();

        public BukuController(IBukuRepository repo, IPenerbitRepository repoPenerbit, IMenuRepository repoMenu, IUserGroupService repoUG)
        {
            this.repo = repo;
            this.repoMenu = repoMenu;
            this.repoUG = repoUG;
            this.repoPenerbit = repoPenerbit;
        }

        string SLUG = "masterdata/buku";
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

            List<string[]> lsParam = new List<string[]>();
            ViewBag.listPenerbit = repoPenerbit.search(lsParam);

            return View(new List<Buku>());
        }

        //public ActionResult IndexSearch(FormCollection objSubmit ,string draw, IEnumerable<Dictionary<string, string>> columns, IEnumerable<Dictionary<string, string>> order, int start, int length, string search, string _)
        //{
        //    IEnumerable<Dictionary<string, string>> param = columns;
        //    var serch = Request.Query["search[value]"];
        //    AES aes = new AES();
        //    List<string[]> lsParam = new List<string[]>();

        //    if (Request.Query["judul"].ToString() != "") lsParam.Add(new string[] { "judul", Request.Query["judul"].ToString() }); ViewBag.judul = Request.Query["judul"].ToString();
        //    if (Request.Query["penerbit_id"].ToString() != "") lsParam.Add(new string[] { "penerbit_id", Request.Query["penerbit_id"].ToString() }); ViewBag.penerbit_id = Request.Query["penerbit_id"].ToString();

        //    ViewBag.chkbocDate = objSubmit["chkboxDateString"].ToString();

        //    if (!String.IsNullOrEmpty(Request.Query["chkboxDate"]))
        //    {
        //        if (Request.Query["start_date"] != "") lsParam.Add(new string[] { "start_date", Request.Query["start_date"] }); ViewBag.start_date = Request.Query["start_date"];
        //        if (Request.Query["end_date"] != "") lsParam.Add(new string[] { "end_date", Request.Query["end_date"] }); ViewBag.end_date = Request.Query["end_date"];
        //        ViewBag.checkedBox = "Y";
        //    }
        //    else
        //    {
        //        ViewBag.checkedBox = "N";
        //    }

        //    foreach (var o in order)
        //    {
        //        o["column"] = "1";
        //    }

        //    try
        //    {
        //        BukuDTO dt = new BukuDTO();

        //        List<string> lsColumns = new List<string>();

        //        lsColumns.Add("no");
        //        lsColumns.Add("judul");
        //        lsColumns.Add("penerbit_id");
        //        lsColumns.Add("tanggal_terbit");
        //        lsColumns.Add("action");

        //        Utils.Datatables.BukudtTbl summarydt = new Utils.Datatables.BukudtTbl(repo);
        //        dt = summarydt.simple(start, length, order, serch, columns, lsColumns, lsParam);

        //        List<List<string>> summarys = new List<List<string>>();
        //        int i = start + 1;

        //        foreach (var d in dt.data)
        //        {
        //            List<string> summary = new List<string>();

        //            string action = "";
        //            action = "<a href=\"" + Url.Action("Edit", "Buku", new { code = aes.Encrypt("BKU", d.bukui_id.ToString()) }) + "\" class=\"icon huge\" title=\"Details User\"><i class=\"fa fa-pencil\"></i></a>&nbsp;";
        //            action += "<a href=\"" + Url.Action("Delete", "Buku", new { code = aes.Encrypt("BKU", d.bukui_id.ToString()) }) + "\" class=\"icon huge\" title=\"Delete User\"><i class=\"fa fa-trash-o\" onclick=\"return confirm('are you sure ?')\"></i></a>&nbsp;";

        //            summary.Add(i.ToString());
        //            summary.Add(d.judul);
        //            summary.Add(d.nama);
        //            summary.Add(d.tanggal_terbit.ToString("yyyy-MM-dd"));
        //            summary.Add(action);

        //            summarys.Add(summary);
        //            i++;
        //        }

        //        UserDTO.returnData models = new UserDTO.returnData();

        //        models.draw = int.Parse(draw);
        //        models.recordsTotal = dt.recordsTotal;
        //        models.recordsFiltered = dt.recordsFiltered;
        //        models.data = summarys;

        //        var json = JsonConvert.SerializeObject(models);

        //        return Json(models);
        //    }
        //    catch (Exception e)
        //    {
        //        TempData["Message"] = e.Message;
        //        TempData["Error"] = "Error";
        //        return RedirectToAction("Index");
        //    }

        //}

        [HttpPost]
        public ActionResult Index(Buku oBuku, IFormCollection objSubmit)
        {
            if (!repoUG.checkPermission(SLUG, "R")) return Redirect("/noauth");

            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/datatables.min.css\" rel=\"stylesheet\" type=\"text/css\" />");
            oCSSRef.addByHtml("<link href=\"/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css\" rel=\"stylesheet\" type=\"text/css\" />");
            Scripts.Add("assets/global/scripts/datatable.js");
            Scripts.Add("assets/global/plugins/datatables/datatables.min.js");
            Scripts.Add("assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js");
            Scripts.Add("assets/modules/js/listDatatables.js");
            Scripts.Add("assets/modules/js/dtTableServerSide.js");            

            try
            {
                List<string[]> lsParam = new List<string[]>();
                if (objSubmit["judul"].ToString() != "") lsParam.Add(new string[] { "judul", objSubmit["judul"].ToString() }); ViewBag.judul = objSubmit["judul"].ToString();
                if (objSubmit["penerbit_id"].ToString() != "") lsParam.Add(new string[] { "penerbit_id", objSubmit["penerbit_id"].ToString() }); ViewBag.penerbit_id = objSubmit["penerbit_id"].ToString();

                if (!String.IsNullOrEmpty(objSubmit["chkboxDate"]))
                {
                    if (objSubmit["start_date"] != "") lsParam.Add(new string[] { "start_date", objSubmit["start_date"] }); ViewBag.start_date = objSubmit["start_date"];
                    if (objSubmit["end_date"] != "") lsParam.Add(new string[] { "end_date", objSubmit["end_date"] }); ViewBag.end_date = objSubmit["end_date"];
                    ViewBag.checkedBox = "Y";
                }
                else
                {
                    ViewBag.checkedBox = "N";
                }

                List<string[]> lsData = new List<string[]>();
                ViewBag.listPenerbit = repoPenerbit.search(lsData);

                TempData["css_controller"] = oCSSRef.toHtmlList();
                TempData["scripts_controller"] = Scripts;
                TempData["current_menu"] = SLUG;
                TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
                TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

                var data = repo.search(lsParam);
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
            if (!repoUG.checkPermission(SLUG, "R")) return Redirect("/noauth");

            TempData["css_controller"] = oCSSRef.toHtmlList();
            TempData["scripts_controller"] = Scripts;
            TempData["current_menu"] = SLUG;
            TempData["menu_tree"] = repoMenu.getHttpMenuTree((string)TempData["current_menu"]);
            TempData["breadcrumb"] = repoMenu.getBreadcrumb((string)TempData["current_menu"]);

            List<string[]> lsParam = new List<string[]>();
            ViewBag.listPenerbit = repoPenerbit.search(lsParam);

            Buku oBuku = new Buku();
            return View("BukuForm", oBuku);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Buku oBuku)
        {
            if (!repoUG.checkPermission(SLUG, "C")) return Redirect("/noauth");

            try
            {
                repo.add(oBuku);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Add");
            }
            TempData["Message"] = "Buku Created Successfully";
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

            List<string[]> lsParam = new List<string[]>();
            ViewBag.listPenerbit = repoPenerbit.search(lsParam);

            AES aes = new AES();
            var id = aes.Decrypt("BKU", code);

            return View("BukuForm", repo.get(int.Parse(id)));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Buku oBuku)
        {
            AES aes = new AES();

            if (!repoUG.checkPermission(SLUG, "U")) return Redirect("/noauth");

            try
            {
                User user = new User();
                var id = Request.Form["buku_id"];
                oBuku.buku_id = int.Parse(id);
                repo.update(oBuku);
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
                TempData["Error"] = "Error";
                return RedirectToAction("Edit", "Buku", new { code = aes.Encrypt("BKU", Request.Form["Buku_id"]) });
            }
            TempData["Message"] = "Buku Updated Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Edit", "Buku", new { code = aes.Encrypt("BKU", Request.Form["Buku_id"]) });

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
            TempData["Message"] = "Buku Deleted Successfully";
            TempData["Success"] = "Success";
            return RedirectToAction("Index");
        }
    }
}