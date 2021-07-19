using Test_FathinMuhammadFadhlullah.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories
{
    public interface IMenuRepository
    {
        List<Menu> search(string filter);

        Menu get(int id);
        List<Menu> getNav(int usergroup_id);
        List<Menu> getRootNav();
        Menu getByName(string menu_name);
        Menu getByUrl(string menu_url);

        Menu add(Menu Menu);
        void update(List<MenuTree> oMenu, string pid);
        bool update(Menu Menu);
        bool del(int id);

        String getNestedMenuTree();
        String getHttpMenuTree(String current_menu_url);
        String getBreadcrumb(String rawUrl);
    }
}
