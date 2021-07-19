using Dapper;
using Dapper.Contrib.Extensions;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Exceptions;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_FathinMuhammadFadhlullah.Repositories.Impl
{
    public class MenuRepository : BaseRepository, IMenuRepository
    {
        public MenuRepository(IConfiguration config) : base(config)
        {

        }

        public Menu add(Menu menu)
        {
            var existing = getByName(menu.menu_name);

            if (existing == null)
            {
                Menu result = null;

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        menu.menu_url = menu.menu_url.ToLower();
                        menu.created_date = DateTime.Now;
                        menu.created_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        menu.updated_date = DateTime.Now;
                        menu.updated_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        conn.Insert<Menu>(menu, tran);

                        tran.Commit();
                        result = menu;
                    }
                }

                return result;
            }
            else
                throw new DuplicateCodeException();
        }

        public void getParentIDs(ref List<int> IDs, Menu oMenu)
        {
            if (oMenu.pid != 0)
            {
                IDs.Add(oMenu.pid);
                Menu parent = get(oMenu.pid);
                getParentIDs(ref IDs, parent);
            }
        }

        public Menu get(int id)
        {
            Menu result = null;

            using (var conn = getConn())
            {
                String sql = @"
                            SELECT
	                            *
                            FROM
	                            menu
                            WHERE
                                menu_id = @id
                            ";

                conn.Open();
                result = conn.Query<Menu>(sql, new { id = id }).FirstOrDefault();

                if (result != null)
                {
                    result.ChildMenus = new List<Menu>();
                    result.hasChild = false;

                    // get child
                    sql = @"
                        SELECT
	                        *
                        FROM
	                        getnav(@usergroup_id)
                        WHERE
                            pid = @id
                        ORDER BY concatenador
                        ";

                    List<Menu> childs = conn.Query<Menu>(sql, new { id = id, usergroup_id = int.Parse(AppHttpContext.Current.Session.GetString("usergroup_id")) }).ToList();
                    foreach (Menu child in childs)
                    {
                        result.ChildMenus.Add(child);
                    }
                    if (result.ChildMenus.Count() > 0) result.hasChild = true;


                    List<int> retVal = new List<int>();
                    getParentIDs(ref retVal, result);
                    result.ParentIDs = retVal;
                }
            }

            return result;
        }

        public Menu getByName(string menu_name)
        {
            Menu result = null;

            using (var conn = getConn())
            {
                String sql = @"
                            SELECT
	                            *
                            FROM
	                            menu
                            WHERE
                                lower(menu_name) = lower(@name)
                            ";

                conn.Open();
                result = conn.Query<Menu>(sql, new { name = menu_name }).FirstOrDefault();

                if (result != null)
                {
                    result.ChildMenus = new List<Menu>();
                    result.hasChild = false;

                    // get child
                    sql = @"
                        SELECT
	                        *
                        FROM
	                        dbo.getnav(@id)
                        WHERE
                            pid = @id
                        ORDER BY concatenador
                        ";

                    List<Menu> childs = conn.Query<Menu>(sql, new { id = result.menu_id }).ToList();
                    foreach (Menu child in childs)
                    {
                        result.ChildMenus.Add(child);
                    }
                    if (result.ChildMenus.Count() > 0) result.hasChild = true;

                    List<int> retVal = new List<int>();
                    getParentIDs(ref retVal, result);
                    result.ParentIDs = retVal;
                }
            }

            return result;
        }

        public Menu getByUrl(string menu_url)
        {
            Menu result = null;

            //if (settingRepo.getByName("is_dev").setting_value.Equals("Y"))
            //{
                using (var conn = getConn())
                {
                    String sql = @"
                            SELECT
	                            *
                            FROM
	                            menu
                            WHERE
                                lower(menu_url) = lower(@url)
                            ";

                    conn.Open();
                    result = conn.Query<Menu>(sql, new { url = menu_url }).FirstOrDefault();

                    if (result != null)
                    {
                        result.ChildMenus = new List<Menu>();
                        result.hasChild = false;

                        // get child
                        sql = @"
                        SELECT
	                        *
                        FROM
	                        getnav(@id)
                        WHERE
                            pid = @id
                        ORDER BY concatenador
                        ";

                        List<Menu> childs = conn.Query<Menu>(sql, new { id = result.menu_id }).ToList();
                        foreach (Menu child in childs)
                        {
                            result.ChildMenus.Add(child);
                        }
                        if (result.ChildMenus.Count() > 0) result.hasChild = true;

                        List<int> retVal = new List<int>();
                        getParentIDs(ref retVal, result);
                        result.ParentIDs = retVal;
                    }
                }
            //}
            //else
            //{
                // LOGIN VIA LDAP
            //}



            return result;
        }

        public List<Menu> getNav(int usergroup_id)
        {
            List<Menu> result = new List<Menu>();

            using (var conn = getConn())
            {
                String sql = @"
                            SELECT
	                            *
                            FROM
	                            dbo.getnav(@id)
                            ";

                conn.Open();
                result = conn.Query<Menu>(sql, new { id = usergroup_id }).ToList();

            }

            return result;
        }

        public List<Menu> getRootNav()
        {
            List<Menu> result = new List<Menu>();
            using (var conn = getConn())
            {
                String sql = @"
                            SELECT
	                            *
                            FROM
	                            getnav(@id)
                            WHERE 
                                level = 1
                            ORDER BY 
                                concatenador
                            ";

                conn.Open();
                result = conn.Query<Menu>(sql, new { id = int.Parse(AppHttpContext.Current.Session.GetString("usergroup_id")) }).ToList();
            }

            return result;
        }

        public List<Menu> search(string filter)
        {
            List<Menu> result = null;

            using (var conn = getConn())
            {
                String sql = @"
                            SELECT
	                            *
                            FROM
	                            menu
                            WHERE
                                menu_name like(@filter)
                                or menu_title like(@filter)
                                or menu_url like(@filter)
                            ";

                conn.Open();
                result = conn.Query<Menu>(sql, new { filter = '%' + filter.ToLower() + '%' }).ToList();

            }

            return result;
        }

        public bool update(Menu menu)
        {
            bool result = false;

            var existing = get(menu.menu_id);

            if (existing != null)
            {
                if (!existing.menu_id.Equals(menu.menu_id))
                {
                    existing = getByName(menu.menu_name);

                    if (existing != null)
                        throw new DuplicateCodeException();
                }

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        existing.menu_name = menu.menu_name;
                        existing.menu_title = menu.menu_title;
                        existing.menu_url = menu.menu_url;
                        existing.menu_url_target = menu.menu_url_target;
                        existing.menu_label_html = menu.menu_label_html;
                        existing.menu_icon = menu.menu_icon;
                        existing.pid = menu.pid;
                        existing.updated_date = DateTime.Now;
                        existing.updated_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        conn.Update<Menu>(existing, tran);

                        tran.Commit();

                        result = true;
                    }
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }

        public bool del(int id)
        {
            bool result = false;

            var existing = get(id);

            if (existing != null)
            {
                using (var conn = getConn())
                {
                    conn.Open();

                    conn.Delete<Menu>(existing);

                    if (existing != null)
                    {
                        String sql2 = @"
                                        SELECT * 
                                        FROM menu 
                                        WHERE pid = @pid
                                        ";
                        var result2 = conn.Query<Menu>(sql2, new { pid = existing.pid }).ToList();
                        if (result2.Count > 0)
                        {
                            foreach (var resSub in result2)
                            {
                                String sql3 = @"
                                        SELECT * 
                                        FROM menu 
                                        WHERE pid = @pid
                                        ";
                                var result3 = conn.Query<Menu>(sql3, new { pid = resSub.pid }).ToList();
                            }
                        }
                    }

                    result = true;
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }


        private void buildMenuStructure(ref System.Text.StringBuilder MenuString, int MenuID, Menu CurrentMenu)
        {
            // Get the menu first
            Menu oMenu = get(MenuID);

            if (oMenu.hasChild == true)
            {
                if (CurrentMenu.ParentIDs.Contains(oMenu.menu_id))
                {
                    MenuString.AppendLine("<li class=\"nav-item start active open\">");
                    MenuString.AppendLine("<a href=\"javascript:; \"  class=\"nav-link nav-toggle\">");
                    MenuString.AppendLine(String.Concat("<i class=\"", oMenu.menu_icon == null ? "" : oMenu.menu_icon, "\"></i>"));
                    MenuString.AppendLine(String.Concat("<span class=\"title\">", oMenu.menu_title, "</span>"));
                    MenuString.AppendLine(String.Concat("<span class=\"selected\">", "", "</span>"));
                    MenuString.AppendLine("<span class=\"arrow open\"></span>");
                    MenuString.AppendLine("</a>");
                    MenuString.AppendLine("<ul class=\"sub-menu\">");
                }
                else
                {
                    MenuString.AppendLine("<li class=\"nav-item\">");
                    MenuString.AppendLine("<a href=\"javascript:; \"  class=\"nav-link nav-toggle\">");
                    MenuString.AppendLine(String.Concat("<i class=\"", oMenu.menu_icon == null ? "" : oMenu.menu_icon, "\"></i>"));
                    MenuString.AppendLine(String.Concat("<span class=\"title\">", oMenu.menu_title, "</span>"));
                    MenuString.AppendLine("<span class=\"arrow \"></span>");
                    MenuString.AppendLine("</a>");
                    MenuString.AppendLine("<ul class=\"sub-menu\">");
                }

                // Repeat the child
                foreach (Menu ChildItem in oMenu.ChildMenus.OrderBy(x => x.menu_position))
                {
                    buildMenuStructure(ref MenuString, ChildItem.menu_id, CurrentMenu);
                }
                MenuString.AppendLine("</ul>");
            }
            else
            {
                if (CurrentMenu.ParentIDs.Contains(oMenu.menu_id) || CurrentMenu.menu_id == oMenu.menu_id)
                {
                    MenuString.AppendLine("<li class=\"nav-item start active open\">");
                    MenuString.AppendLine(String.Concat("<a href=\"", UrlExtensions.AbsoluteContent((oMenu.menu_url)), "\"  class=\"nav-link nav-toggle\">"));
                    MenuString.AppendLine(String.Concat("<i class=\"", oMenu.menu_icon == null ? "" : oMenu.menu_icon, "\"></i>"));
                    MenuString.AppendLine(String.Concat("<span class=\"title\">", oMenu.menu_title, "</span>"));
                    MenuString.AppendLine(String.Concat("<span class=\"selected\">", "", "</span>"));
                    MenuString.AppendLine("</a>");
                }
                else
                {
                    MenuString.AppendLine("<li class=\"nav-item\">");
                    MenuString.AppendLine(String.Concat("<a href=\"", UrlExtensions.AbsoluteContent(oMenu.menu_url), "\" class=\"nav-link\" >"));
                    MenuString.AppendLine(String.Concat("<i class=\"", oMenu.menu_icon == null ? "" : oMenu.menu_icon, "\"></i>"));
                    MenuString.AppendLine(String.Concat("<span class=\"title\">", oMenu.menu_title, "</span>"));
                    MenuString.AppendLine("</a>");
                }
            }
            MenuString.AppendLine("</li>");
        }

        public String getNestedMenuTree()
        {
            String retVal = "";
            System.Text.StringBuilder NestedElement = new System.Text.StringBuilder();

            List<Menu> rootNav = getRootNav();

            foreach (Menu item in rootNav)
            {
                buildNestedMenuTree(ref NestedElement, (int)item.menu_id);
            }

            retVal = NestedElement.ToString();

            return retVal;
        }

        public void buildNestedMenuTree(ref System.Text.StringBuilder NestedElement, int MenuID)
        {
            // Get the menu first 
            Menu oMenu = get(MenuID);
            if (oMenu.hasChild == true)
            {
                NestedElement.AppendLine(String.Concat("<li data-id = \"", oMenu.menu_id.ToString(), "\" class=\"dd-item dd3-item\">"));
                NestedElement.AppendLine("<div class=\"dd-handle dd3-handle\" style=\"\">");
                NestedElement.AppendLine("</div>");
                NestedElement.AppendLine("<div class=\"dd3-content\">");
                NestedElement.AppendLine(oMenu.menu_title);
                NestedElement.AppendLine("</div>");

                // AddSubmenus
                NestedElement.AppendLine("<ol class=\"dd-list\">");

                // Repeat the child
                foreach (Menu ChildItem in oMenu.ChildMenus)
                {
                    buildNestedMenuTree(ref NestedElement, ChildItem.menu_id);
                }
                NestedElement.AppendLine("</ol>");
                NestedElement.AppendLine("</li>");
            }
            else
            {
                NestedElement.AppendLine(String.Concat("<li data-id = \"", oMenu.menu_id.ToString(), "\" class=\"dd-item dd3-item\">"));
                NestedElement.AppendLine("<div class=\"dd-handle dd3-handle\">");

                NestedElement.AppendLine("</div>");
                NestedElement.AppendLine("<div class=\"dd3-content\">");
                NestedElement.AppendLine(oMenu.menu_title);
                NestedElement.AppendLine("</div>");
                NestedElement.AppendLine("</li>");

            }
        }

        public String getHttpMenuTree(String current_menu_url)
        {
            String retVal = "";

            Menu oCurrentMenu = getByUrl(current_menu_url);

            System.Text.StringBuilder MenuStr = new System.Text.StringBuilder();

            foreach (Menu item in getRootNav())
            {
                buildMenuStructure(ref MenuStr, (int)item.menu_id, oCurrentMenu);
            }

            retVal = MenuStr.ToString();

            return retVal;
        }

        // Build Breadcrumb
        public String getBreadcrumb(String rawUrl)
        {

            String sBreadCrumbHtml = "";
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            System.Text.StringBuilder insideBuilder = new System.Text.StringBuilder();


            strBuilder.AppendFormat("<ul class=\"page-breadcrumb breadcrumb\">");
            strBuilder.AppendFormat("<li>");
            strBuilder.AppendFormat("<a href=\"" + UrlExtensions.AbsoluteContent("home") + "\">Home</a>");
            strBuilder.AppendFormat("<i class=\"fa fa-circle\"></i>");
            strBuilder.AppendFormat("</li>");

            Menu oMenu = getByUrl(rawUrl);
            buildBreadCrumb(oMenu, ref insideBuilder);

            strBuilder.Append(insideBuilder.ToString());
            strBuilder.AppendFormat("</ul>");

            sBreadCrumbHtml = strBuilder.ToString();
            return sBreadCrumbHtml;
        }

        private void buildBreadCrumb(Menu oMenu, ref System.Text.StringBuilder strBuilder)
        {
            System.Text.StringBuilder oNewStrBuilder = new System.Text.StringBuilder();

            if (oMenu.pid != 0)
            {
                Menu parentMenu = get(oMenu.pid);
                buildBreadCrumb(parentMenu, ref oNewStrBuilder);
                oNewStrBuilder.AppendFormat("<li>");
                oNewStrBuilder.AppendFormat("<span>");
                oNewStrBuilder.AppendFormat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oMenu.menu_title));
                oNewStrBuilder.AppendFormat("</span>");
            }
            else
            {
                oNewStrBuilder.AppendFormat("<li>");
                oNewStrBuilder.AppendFormat("<span>");
                oNewStrBuilder.AppendFormat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oMenu.menu_title));
                oNewStrBuilder.AppendFormat("</span>");
            }


            if (oMenu.hasChild == true)
            {
                oNewStrBuilder.AppendFormat("<i class=\"fa fa-circle\"></i>");
            }

            oNewStrBuilder.AppendFormat("</li>");

            strBuilder.Insert(0, oNewStrBuilder.ToString());

        }


        public void update(List<MenuTree> oMenu, string pid)
        {
            for (int i = 0; i < oMenu.Count; i++)
            {
                var existing = get(Convert.ToInt32(oMenu[i].id));
                if (existing != null)
                {
                    using (var conn = getConn())
                    {
                        conn.Open();
                        existing.updated_date = DateTime.Now;
                        existing.updated_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        existing.pid = Convert.ToInt32(pid);
                        existing.menu_position = i + 1;
                        conn.Update<Menu>(existing);

                        if (oMenu[i].children != null && oMenu[i].children.Count > 0)
                        {
                            update(oMenu[i].children, oMenu[i].id);
                        }
                    }
                }
            }
        }

    }
}
