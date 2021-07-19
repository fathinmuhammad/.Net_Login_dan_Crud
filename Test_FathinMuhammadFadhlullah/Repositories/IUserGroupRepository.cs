using Test_FathinMuhammadFadhlullah.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories
{
    public interface IUserGroupRepository
    {
        List<UserGroup> search(string filter);
        Boolean checkPermission(string _slug, string _actions);

        UserGroup get(int id);
        UserGroup getByName(string ugname);

        UserGroup add(UserGroup user);
        bool update(UserGroup user);
        bool del(int id);
        IEnumerable<UserPermission> getByKey(string id, Impl.UserGroupRepository.KeyType key);
        UserPermission getBykey(int id, int menu_id);
        bool updatePer(UserPermission up);
        List<Menu> getNav();
    }
}
