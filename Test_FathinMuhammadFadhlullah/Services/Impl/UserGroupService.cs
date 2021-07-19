using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Repositories;
using Test_FathinMuhammadFadhlullah.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Services.Impl
{
    public class UserGroupService : IUserGroupService
    {
        protected IUserGroupRepository repo;

        public UserGroupService(IUserGroupRepository repo)
        {
            this.repo = repo;
        }

        public UserGroup add(UserGroup ug)
        {
            repo.add(ug);
            return ug;
        }

        public bool checkPermission(string _slug, string _actions)
        {
            return repo.checkPermission(_slug, _actions);
        }

        public bool del(int id)
        {
            bool result = false;
            try
            {
                repo.del(id);
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public UserGroup get(int id)
        {
            return repo.get(id);
        }

        public UserGroup getByName(string ugname)
        {
            return repo.getByName(ugname);
        }

        public List<UserGroup> search(string filter)
        {
            List<UserGroup> result = repo.search(filter);

            return result;
        }

        public bool update(UserGroup ug)
        {
            bool result = false;
            if (repo.update(ug)) result = true;

            return result;
        }

        public bool updatePer(UserPermission up)
        {
            bool result = false;
            if (repo.updatePer(up)) result = true;

            return result;
        }

        public IEnumerable<UserPermission> getByKey(string id, Repositories.Impl.UserGroupRepository.KeyType key)
        {
            return repo.getByKey(id, key);
        }

        public UserPermission getBykey(int id, int menu_id)
        {
            return repo.getBykey(id, menu_id);
        }

        public List<Menu> getNav()
        {
            return repo.getNav();
        }
    }
}
