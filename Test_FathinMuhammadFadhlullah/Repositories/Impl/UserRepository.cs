using Dapper;
using Dapper.Contrib.Extensions;
using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Exceptions;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories.Impl
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        AES aES = null;

        public UserRepository(IConfiguration config) : base(config)
        {

        }

        public User add(User user)
        {
            aES = new AES();
            var existing = getByUsername(user.username);

            if (existing == null)
            {
                User result = new User();

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        string newPassword = aES.Encrypt("USR", user.password);

                        user.password = newPassword;
                        user.created_date = DateTime.Now;
                        user.created_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        user.updated_date = DateTime.Now;
                        user.updated_user = AppHttpContext.Current.Session.GetString("username").ToString();               
                    
                        conn.Insert(user, tran);
                        conn.Update<User>(user, tran);

                        tran.Commit();
                        result = user;
                    }
                }

                return result;
            }
            else
                throw new DuplicateCodeException();
        }

        public User get(int id)
        {
            User result = null;

            using (var conn = getConn())
            {
                var sql = @"
                            SELECT
	                            *
                            FROM
	                            usr
                            WHERE
                                user_id = @id
                            ";

                conn.Open();
                result = conn.Query<User>(sql, new { id = id }).FirstOrDefault();

            }

            return result;
        }

        public User getByUsername(string username)
        {
            User result = null;

            using (var conn = getConn())
            {
                var sql = @"
                         SELECT
                            A.*, B.usergroup_name
                        FROM
                            usr A 
                        inner join usergroup B on A.usergroup_id=B.usergroup_id
                        WHERE
                           A.username = @username
                        ";

                conn.Open();
                result = conn.Query<User>(sql, new { username = username }).FirstOrDefault();
            }

            return result;
        }

        public List<User> search(List<string[]> param = null)
        {
            List<User> result = null;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "username":
                            sWhere += " AND U.username ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "fullname":
                            sWhere += " AND U.fullname ilike '%" + sParam[1].ToString() + "%'";
                            break;
                    }
                }
                
                var sql = @"
                              SELECT
	                            U.*,
                                UG.usergroup_name,
                            FROM
	                            usr U
	                        INNER JOIN usergroup UG ON U.usergroup_id = UG.usergroup_id
                           " + sWhere;
                result = conn.Query<User>(sql).ToList();

            }

            return result;
        }

        public bool update(User user, string updatedUser = "")
        {
            aES = new AES();
            bool result = false;
            string key =Helper.GenerateRandomSalt(32);

            var prev = get(user.user_id);
            var existing = get(user.user_id);

            if (existing != null)
            {
                if (!existing.user_id.Equals(user.user_id))
                {
                    existing = getByUsername(user.username);

                    if (existing != null)
                        throw new DuplicateCodeException();
                }

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        if (!updatedUser.Equals(""))
                        {
                            existing.updated_date = DateTime.Now;
                            existing.updated_user = (!updatedUser.Equals("")) ? updatedUser : AppHttpContext.Current.Session.GetString("username").ToString();
                            existing.created_date = DateTime.Now;
                            existing.created_user = (!updatedUser.Equals("")) ? updatedUser : AppHttpContext.Current.Session.GetString("username").ToString();
                        }
                        else
                        {
                            existing.updated_date = DateTime.Now;
                            existing.updated_user = (!updatedUser.Equals("")) ? updatedUser : AppHttpContext.Current.Session.GetString("username").ToString();
                            existing.fullname = user.fullname;
                            existing.usergroup_id = user.usergroup_id;
                            
                            if (user.password != null)
                            {
                                string hashedPassword = aES.Encrypt("USR", user.password.ToString());
                                existing.password = hashedPassword;
                            }
                        }
                        conn.Update<User>(existing, tran);

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

                    using (var tran = conn.BeginTransaction())
                    {
                        conn.Delete<User>(existing, tran);

                        tran.Commit();

                        result = true;
                    }
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }

        public List<User> getListActive()
        {
            List<User> result = new List<User>();

            using (var conn = getConn())
            {
                var sql = @"
                            SELECT
	                            *
                            FROM
	                            usr
                            WHERE COALESCE(USER_ACTIVE,'N') = 'Y' " + (AppHttpContext.Current.Session.GetString("company_id") != "0" ? " AND company_id = " + AppHttpContext.Current.Session.GetString("company_id") : "");

                conn.Open();
                result = conn.Query<User>(sql).ToList();
            }

            return result;
        }

        public List<UserDTO.User> getListdtTable(string wheres, string orders, string limits, List<string[]> param = null)
        {
            List<UserDTO.User> result = null;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "username":
                            sWhere += " AND U.username ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "fullname":
                            sWhere += " AND U.fullname ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "usergroup_id":
                            sWhere += String.Format(" AND U.{0} {1} {2}", sParam[0], sParam[1], sParam[2]);
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            U.*,
                                UG.usergroup_name
                            FROM
	                            usr U
	                        INNER JOIN usergroup UG ON U.usergroup_id = UG.usergroup_id
                           " + sWhere;

                sql += wheres + orders + limits;

                result = conn.Query<UserDTO.User>(sql).ToList();

            }

            return result;
        }

        public int resFilterLength(string wheres, List<string[]> param = null)
        {
            int result = 0;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "username":
                            sWhere += " AND U.username ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "fullname":
                            sWhere += " AND U.fullname ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "usergroup_id":
                            sWhere += String.Format(" AND U.{0} {1} {2}", sParam[0], sParam[1], sParam[2]);
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            U.*,
                                UG.usergroup_name
                            FROM
	                            usr U
	                        INNER JOIN usergroup UG ON U.usergroup_id = UG.usergroup_id
                           " + sWhere;

                sql += wheres ;

                result = conn.Query<UserDTO.User>(sql).ToList().Count();

            }

            return result;
        }

        public int resTotalLength(List<string[]> param = null)
        {
            int result = 0;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "username":
                            sWhere += " AND U.username ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "fullname":
                            sWhere += " AND U.fullname ilike '%" + sParam[1].ToString() + "%'";
                            break;
                        case "usergroup_id":
                            sWhere += String.Format(" AND U.{0} {1} {2}", sParam[0], sParam[1], sParam[2]);
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            U.*,
                                UG.usergroup_name
                            FROM
	                            usr U
	                        INNER JOIN usergroup UG ON U.usergroup_id = UG.usergroup_id
                           " + sWhere;

                result = conn.Query<UserDTO.User>(sql).ToList().Count();

            }

            return result;
        }
    }
}
