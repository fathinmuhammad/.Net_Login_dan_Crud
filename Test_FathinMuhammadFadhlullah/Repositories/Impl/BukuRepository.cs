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
    public class BukuRepository : BaseRepository, IBukuRepository
    {
        public BukuRepository(IConfiguration config) : base(config)
        {

        }

        public Buku add(Buku buku)
        {
            var existing = getByJudul(buku.judul);

            if (existing == null)
            {
                Buku result = null;

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        buku.judul = buku.judul;
                        buku.tanggal_terbit = buku.tanggal_terbit;
                        buku.penerbit_id = buku.penerbit_id;
                        buku.created_date = DateTime.Now;
                        buku.created_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        conn.Insert<Buku>(buku, tran);

                        tran.Commit();
                        result = buku;
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
                        conn.Delete<Buku>(existing, tran);

                        tran.Commit();

                        result = true;
                    }
                }
            }
            else
                throw new DataNotExistException();

            return result;
        }

        public Buku get(int id)
        {
            Buku result = null;

            using (var conn = getConn())
            {
                var sql = @"
                            SELECT
	                            *
                            FROM
	                            buku
                            WHERE
                                buku_id = @id
                            ";

                conn.Open();
                result = conn.Query<Buku>(sql, new { id = id }).FirstOrDefault();

            }

            return result;
        }

        public Buku getByJudul(string judul)
        {
            Buku result = null;

            using (var conn = getConn())
            {
                var sql = @"
                         SELECT
                            A.*
                        FROM
                            buku A 
                        WHERE
                           A.judul = @judul
                        ";

                conn.Open();
                result = conn.Query<Buku>(sql, new { judul = judul }).FirstOrDefault();
            }

            return result;
        }

        public List<BukuDTO.Buku> getListdtTable(string wheres, string orders, string limits, List<string[]> param = null)
        {
            List<BukuDTO.Buku> result = null;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "judul":
                            sWhere += " AND A.judul like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "penerbit_id":
                            sWhere += " AND A.penerbit_id = '" + sParam[1].ToString() + "'";
                            break;
                        case "start_date":
                            sWhere += " AND to_date(to_char(A.tanggal_terbit,'DD-MM-YYYY'),'DD-MM-YYYY') >= to_date('" + sParam[1].ToString() + "','DD-MM-YYYY')";
                            break;
                        case "end_date":
                            sWhere += " AND to_date(to_char(A.tanggal_terbit,'DD-MM-YYYY'),'DD-MM-YYYY') <= to_date('" + sParam[1].ToString() + "','DD-MM-YYYY')";
                            break;
                    }
                }

                var sql = @"
                            SELECT
	                            A.*, B.nama
                            FROM
	                            buku A
                            INNER JOIN penerbit B on A.penerbit_id=B.penerbit_id
                           " + sWhere;

                sql += wheres + orders + limits;

                result = conn.Query<BukuDTO.Buku>(sql).ToList();

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
                        case "judul":
                            sWhere += " AND A.judul like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "penerbit_id":
                            sWhere += " AND A.penerbit_id = '" + sParam[1].ToString() + "'";
                            break;
                        case "start_date":
                            sWhere += " AND to_date(to_char(A.tanggal_terbit,'DD-MM-YYYY'),'DD-MM-YYYY') >= to_date('" + sParam[1].ToString() + "','DD-MM-YYYY')";
                            break;
                        case "end_date":
                            sWhere += " AND to_date(to_char(A.tanggal_terbit,'DD-MM-YYYY'),'DD-MM-YYYY') <= to_date('" + sParam[1].ToString() + "','DD-MM-YYYY')";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*, B.nama
                            FROM
	                            buku A
                            INNER JOIN penerbit B on A.penerbit_id=B.penerbit_id
                           " + sWhere;

                sql += wheres;

                result = conn.Query<BukuDTO.Buku>(sql).ToList().Count();

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
                        case "judul":
                            sWhere += " AND A.judul like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "penerbit_id":
                            sWhere += " AND A.penerbit_id = '" + sParam[1].ToString() + "'";
                            break;
                        case "start_date":
                            sWhere += " AND to_date(to_char(A.tanggal_terbit,'DD-MM-YYYY'),'DD-MM-YYYY') >= to_date('" + sParam[1].ToString() + "','DD-MM-YYYY')";
                            break;
                        case "end_date":
                            sWhere += " AND to_date(to_char(A.tanggal_terbit,'DD-MM-YYYY'),'DD-MM-YYYY') <= to_date('" + sParam[1].ToString() + "','DD-MM-YYYY')";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*, B.nama
                            FROM
	                            buku A
                            INNER JOIN penerbit B on A.penerbit_id=B.penerbit_id
                           " + sWhere;

                result = conn.Query<BukuDTO.Buku>(sql).ToList().Count();

            }

            return result;
        }

        public List<Buku> search(List<string[]> param = null)
        {
            List<Buku> result = null;
            string sWhere = " WHERE 1 = 1  ";

            using (var conn = getConn())
            {
                conn.Open();

                foreach (String[] sParam in param)
                {
                    switch (sParam[0])
                    {
                        case "judul":
                            sWhere += " AND A.judul like '%" + sParam[1].ToString() + "%'";
                            break;
                        case "penerbit_id":
                            sWhere += " AND A.penerbit_id = '" + sParam[1].ToString() + "'";
                            break;
                        case "start_date":
                            sWhere += " and A.tanggal_terbit between CONVERT(date, '" + sParam[1].ToString() + "', 105)";
                            break;
                        case "end_date":
                            sWhere += " AND CONVERT(date, '" + sParam[1].ToString() + "', 105)";
                            break;
                    }
                }

                var sql = @"
                              SELECT
	                            A.*, B.nama
                            FROM
	                            buku A
                            INNER JOIN penerbit B on A.penerbit_id=B.penerbit_id
                           " + sWhere;
                result = conn.Query<Buku>(sql).ToList();

            }

            return result;
        }

        public bool update(Buku buku)
        {
            bool result = false;

            var existing = get(buku.buku_id);

            if (existing != null)
            {
                if (!existing.buku_id.Equals(buku.buku_id))
                {
                    existing = getByJudul(buku.judul);

                    if (existing != null)
                        throw new DuplicateCodeException();
                }

                using (var conn = getConn())
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        existing.judul = buku.judul;
                        existing.tanggal_terbit = buku.tanggal_terbit;
                        existing.penerbit_id = buku.penerbit_id;
                        existing.updated_date = DateTime.Now;
                        existing.updated_user = AppHttpContext.Current.Session.GetString("username").ToString();
                        conn.Update<Buku>(existing, tran);

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
