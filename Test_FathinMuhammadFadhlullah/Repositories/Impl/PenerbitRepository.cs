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
using Test_FathinMuhammadFadhlullah.DTO.Ajax;

namespace Test_FathinMuhammadFadhlullah.Repositories.Impl
{
    public class PenerbitRepository : BaseRepository, IPenerbitRepository
    {
        public PenerbitRepository(IConfiguration config) : base(config)
        {

        }

        public Penerbit add(Penerbit penerbit)
        {
            var existing = getByName(penerbit.nama);

            if (existing == null)
            {
                Penerbit result = null;

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        penerbit.nama = penerbit.nama;
                        penerbit.alamat = penerbit.alamat;
                        penerbit.created_date = DateTime.Now;
                        penerbit.created_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        conn.Insert<Penerbit>(penerbit, tran);

                        tran.Commit();
                        result = penerbit;
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

                    using (var tran = conn.BeginTransaction())
                    {
                        conn.Delete<Penerbit>(existing, tran);

                        tran.Commit();

                        result = true;
                    }
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }

        public Penerbit get(int id)
        {
            Penerbit result = null;

            using (var conn = getConn())
            {
                var sql = @"
                            SELECT
	                            *
                            FROM
	                            penerbit
                            WHERE
                                penerbit_id = @id
                            ";

                conn.Open();
                result = conn.Query<Penerbit>(sql, new { id = id }).FirstOrDefault();

            }

            return result;
        }

        public Penerbit getByName(string nama)
        {
            Penerbit result = null;

            using (var conn = getConn())
            {
                var sql = @"
                         SELECT
                            A.*
                        FROM
                            penerbit A 
                        WHERE
                           A.nama = @nama
                        ";

                conn.Open();
                result = conn.Query<Penerbit>(sql, new { nama = nama }).FirstOrDefault();
            }

            return result;
        }

        public List<PenerbitDTO.Penerbit> getListdtTable(string wheres, string orders, string limits, List<string[]> param = null)
        {
            List<PenerbitDTO.Penerbit> result = null;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "nama":
                            sWhere += " AND A.nama like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "alamat":
                            sWhere += " AND A.alamat like '%" + sParam[1].ToString() + "%'";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*
                            FROM
	                            penerbit A
                           " + sWhere;

                sql += wheres + orders + limits;

                result = conn.Query<PenerbitDTO.Penerbit>(sql).ToList();

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
                        case "nama":
                            sWhere += " AND A.nama like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "alamat":
                            sWhere += " AND A.alamat like '%" + sParam[1].ToString() + "%'";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*
                            FROM
	                            penerbit A
                           " + sWhere;

                sql += wheres;

                result = conn.Query<PenerbitDTO.Penerbit>(sql).ToList().Count();

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
                        case "nama":
                            sWhere += " AND A.nama like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "alamat":
                            sWhere += " AND A.alamat like '%" + sParam[1].ToString() + "%'";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*
                            FROM
	                            penerbit A
                           " + sWhere;

                result = conn.Query<PenerbitDTO.Penerbit>(sql).ToList().Count();

            }

            return result;
        }

        public List<Penerbit> search(List<string[]> param = null)
        {
            List<Penerbit> result = null;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "nama":
                            sWhere += " AND A.nama like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "alamat":
                            sWhere += " AND A.alamat like '%" + sParam[1].ToString() + "%'";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*
                            FROM
	                            penerbit A
                           " + sWhere;
                result = conn.Query<Penerbit>(sql).ToList();

            }

            return result;
        }

        public bool update(Penerbit penerbit)
        {
            bool result = false;

            var existing = get(penerbit.penerbit_id);

            if (existing != null)
            {
                if (!existing.penerbit_id.Equals(penerbit.penerbit_id))
                {
                    existing = getByName(penerbit.nama);

                    if (existing != null)
                        throw new DuplicateCodeException();
                }

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        existing.nama = penerbit.nama;
                        existing.alamat = penerbit.alamat;
                        existing.updated_date = DateTime.Now;
                        existing.updated_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        conn.Update<Penerbit>(existing, tran);

                        tran.Commit();

                        result = true;
                    }
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }
    }
}
