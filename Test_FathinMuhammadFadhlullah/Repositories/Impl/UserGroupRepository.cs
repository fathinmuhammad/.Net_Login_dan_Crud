using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Exceptions;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Test_FathinMuhammadFadhlullah.Repositories.Impl
{
    public class UserGroupRepository : BaseRepository, IUserGroupRepository
    {
        protected IMenuRepository mnSvc;

        public UserGroupRepository(IConfiguration config) : base(config)
        {
            mnSvc = new MenuRepository(config);
        }

        public UserGroup add(UserGroup ug)
        {
            var existing = getByName(ug.usergroup_name);

            if (existing == null)
            {
                UserGroup result = null;

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        ug.created_date = DateTime.Now;
                        ug.created_user = AppHttpContext.Current.Session.GetString("username");
                        ug.updated_date = DateTime.Now;
                        ug.updated_user = AppHttpContext.Current.Session.GetString("username");
                        conn.Insert<UserGroup>(ug, tran);

                        tran.Commit();
                        result = ug;
                    }
                }

                return result;
            }
            else
                throw new DuplicateCodeException();
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

                    conn.Delete<UserGroup>(existing);

                    result = true;
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }

        public UserGroup getByName(string ugname)
        {
            UserGroup result = null;

            using (var conn = getConn())
            {
                var sql = @"
                            SELECT
	                            *
                            FROM
	                            usergroup
                            WHERE
                                lower(usergroup_name) = lower(@ugname)
                            ";

                conn.Open();
                result = conn.Query<UserGroup>(sql, new { ugname = ugname }).FirstOrDefault();

            }

            return result;
        }

        public UserGroup get(int id)
        {
            UserGroup result = null;


            using (var conn = getConn())
            {
                var sql = @"
                            SELECT
	                            *
                            FROM
	                            usergroup
                            WHERE
                                usergroup_id = @id
                            ";

                conn.Open();
                result = conn.Query<UserGroup>(sql, new { id = id }).FirstOrDefault();

                if (result != null)
                {
                    result.ListPermission = null;

                    sql = @"
                            SELECT 
	                            A.usergroupmenu_id,A.usergroup_id,B.usergroup_name,A.menu_id,
	                            C.menu_name,ISNULL(A.create_perm,0) as create_perm,ISNULL(A.edit_perm,0) as edit_perm,ISNULL(A.view_perm,0) as view_perm,
	                            ISNULL(A.delete_perm,0) as delete_perm,ISNULL(A.cancel_perm,0) as cancel_perm 
                            FROM usrp A 
	                            INNER JOIN usergroup B ON A.usergroup_id=B.usergroup_id
	                            INNER JOIN menu C ON A.menu_id=C.menu_id
                            WHERE A.usergroup_id = @id";

                    result.ListPermission = conn.Query<UserPermission>(sql, new { id = Convert.ToInt32(id) }).ToList();
                }
            }

            return result;
        }

        public List<UserGroup> search(string filter)
        {
            List<UserGroup> result = null;

            using (var conn = getConn())
            {
                conn.Open();

                var sql = @"
                        SELECT
	                        *
                        FROM
	                        usergroup
                        WHERE
                            lower(usergroup_name) like (@filter)
                        ";
                result = conn.Query<UserGroup>(sql, new { filter = '%' + filter.ToLower() + '%' }).ToList();

            }

            return result;
        }

        public bool update(UserGroup ug)
        {
            bool result = false;

            var existing = get(ug.usergroup_id);

            if (existing != null)
            {
                if (!existing.usergroup_id.Equals(ug.usergroup_id))
                {
                    existing = getByName(ug.usergroup_name);

                    if (existing != null)
                        throw new DuplicateCodeException();
                }

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        existing.usergroup_name = ug.usergroup_name;
                        existing.updated_date = DateTime.Now;
                        existing.updated_user = AppHttpContext.Current.Session.GetString("username");
                        conn.Update<UserGroup>(existing, tran);

                        tran.Commit();

                        result = true;
                    }
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }

        public bool updatePer(UserPermission up)
        {
            bool result = false;

            using (var conn = getConn())
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    up.created_date = DateTime.Now;
                    up.updated_date = DateTime.Now;
                    conn.Update<UserPermission>(up, tran);

                    tran.Commit();

                    result = true;
                }
            }

            return result;
        }


        public Boolean checkPermission(string _slug, string _actions)
        {
            Boolean result = false;

            using (var conn = getConn())
            {
                var sql = @"
                        SELECT
	                        1
                        FROM
	                        menu mn 
                        JOIN usrp usrp ON mn.menu_id = usrp.menu_id
                        WHERE
                            mn.menu_url = lower(@slug) and usrp.usergroup_id = @usergroupid
                        ";

                switch (_actions)
                {
                    case "C":
                        sql = sql + " AND usrp.create_perm = 1"; break;
                    case "R":
                        sql = sql + " AND usrp.view_perm = 1"; break;
                    case "U":
                        sql = sql + " AND usrp.edit_perm = 1"; break;
                    case "D":
                        sql = sql + " AND usrp.delete_perm = 1"; break;
                    case "CA":
                        sql = sql + " AND usrp.cancel_perm = 1"; break;
                }

                conn.Open();

                int havePermit = conn.Query<int>(sql, new { slug = _slug, usergroupid = int.Parse(AppHttpContext.Current.Session.GetString("usergroup_id")) }).FirstOrDefault();

                if (havePermit > 0) result = true;
            }

            return result;
        }

        #region Enums
        /// <summary>
        /// Key Types
        /// </summary>
        public enum KeyType
        {
            // Keys List
            usergroup_id = 0,
            usergroup_name = 1
        }
        #endregion

        public UserPermission getBykey(int id, int menu_id)
        {
            UserPermission result = null;

            using (var conn = getConn())
            {
                string sql = @"
                                SELECT * 
                                FROM
                                    usrp
                                WHERE 
                                    usergroup_id = @ugid and menu_id = @menuid
                                ";
                result = conn.Query<UserPermission>(sql, new { ugid = id, menuid = menu_id }).FirstOrDefault();
            }

            return result;
        }

        public List<Menu> getNav()
        {
            List<Menu> result = new List<Menu>();

            using (var conn = getConn())
            {
                String sql = @"
                            WITH MyCTE
                                AS 
                                (  
	                                SELECT mn.menu_id, isnull(mn.pid,0) as pid, mn.menu_name as menu_name, mn.menu_title as title, 
		                                cast(isnull(mn.menu_url,'') as nvarchar(255)) as url,
		                                CAST(isnull(menu_url,'') AS NVARCHAR(255)) as menu_path,
		                                isnull(mn.menu_icon,'') as icon,
		                                1 AS Level,
		                                CONVERT(VARCHAR (MAX), menu_id) as hierarcy,
		                                '('+CONVERT(VARCHAR (MAX), RIGHT('000'+CAST(menu_position AS VARCHAR(3)),3))+' - '+CONVERT(VARCHAR (MAX), 2)+')' as concatenador
	                                FROM menu mn  
	                                WHERE isnull(mn.pid,0) = 0
	                                UNION ALL
	                                SELECT mn.menu_id, mn.pid, mn.menu_name, mn.menu_title, 
		                                cast(isnull(mn.menu_url,'') as nvarchar(255)) as url, 
		                                CAST(isnull(mn.menu_url,'') + ',' + MyCTE.menu_path AS NVARCHAR(255)) as menu_path, 
		                                isnull(mn.menu_icon,'') as icon,
		                                MyCTE.Level + 1 AS Level,
		                                MyCTE.hierarcy+','+CONVERT(VARCHAR (MAX), mn.menu_id) as hierarcy,
		                                MyCTE.concatenador+' * ('+CONVERT (VARCHAR (MAX), case when ISNULL(mn.pid, 0) = 0 then 0 else RIGHT('000'+CAST(mn.menu_position AS VARCHAR(3)),3) END)+')' as concatenador
	                                FROM menu mn
	                                INNER JOIN MyCTE ON mn.pid = MyCTE.menu_id
	                                WHERE mn.pid <> 0 
                                ) 
                                SELECT DISTINCT MyCTE.* from MyCTE
                            ";

                conn.Open();
                result = conn.Query<Menu>(sql).ToList();

            }

            return result;
        }

        public IEnumerable<UserPermission> getByKey(string id, KeyType key)
        {
            IEnumerable<UserPermission> result = null;

            using (var conn = getConn())
            {
                String sql = @"
                            SELECT 
	                            A.usergroupmenu_id,A.usergroup_id,B.usergroup_name,A.menu_id,
	                            C.menu_name,COALESCE(A.create_perm,0) as create_perm,COALESCE(A.edit_perm,0) as edit_perm,COALESCE(A.view_perm,0) as view_perm,
	                            COALESCE(A.delete_perm,0) as delete_perm,COALESCE(A.cancel_perm,0) as cancel_perm
	                        FROM usrp A 
	                            INNER JOIN usergroup B ON A.usergroup_id=B.usergroup_id
	                            RIGHT JOIN menu C ON A.menu_id=C.menu_id
                            ";

                conn.Open();

                switch (key)
                {
                    case KeyType.usergroup_id:
                        sql = sql + " AND A.usergroup_id = @id";
                        result = conn.Query<UserPermission>(sql, new { id = Convert.ToInt32(id) }).ToList();
                        break;
                    case KeyType.usergroup_name:
                        sql = sql + " AND B.usergroup_name = @id";
                        result = conn.Query<UserPermission>(sql, new { id = id }).ToList();
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
