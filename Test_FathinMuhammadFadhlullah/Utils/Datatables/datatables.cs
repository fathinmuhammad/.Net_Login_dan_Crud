using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Utils.Datatables
{
    public class datatables
    {
        public static string limit(int start, int length, List<Dictionary<string, string>> columns)
        {
            var limit = "";
            if (length != -1)
            {
                limit = " OFFSET " + start + " ROWS FETCH NEXT " + length + " ROWS ONLY ";
                //limit = " LIMIT " + length + " OFFSET " + start + " ";
            }
            return limit;
        }

        public static string order(List<Dictionary<string, string>> order, List<Dictionary<string, string>> columns, List<string> lsColumns)
        {
            columns.RemoveRange(lsColumns.Count(), columns.Count - lsColumns.Count());

            var orders = "";
            if (order != null && order.Count() > 0)
            {
                List<string> orderBy = new List<string>();
                //var dtColumns = columns.Select(q => q.Keys.Where(a => a == "dt" ));
                var ien = order.Count();
                for (int i = 0; i < ien; i++)
                {
                    // Convert the column index into the column data property
                    var columnIdx = int.Parse(order[i].Where(q => q.Key == "column").FirstOrDefault().Value);
                    var requestColumn = columns[columnIdx];
                    columnIdx = int.Parse(requestColumn.Where(q => q.Key == "data").FirstOrDefault().Value);
                    var column = columns[columnIdx];
                    if (requestColumn.Where(q => q.Key == "orderable").FirstOrDefault().Value == "true")
                    {
                        var dir = order[i].Where(q => q.Key == "dir").FirstOrDefault().Value == "asc" ? "ASC" : "DESC";
                        if (lsColumns[columnIdx] == "no" || lsColumns[columnIdx] == "action") continue;
                        orderBy.Add(' ' + lsColumns[columnIdx] + " " + dir);
                    }
                }
                if (orderBy.Count() > 0)
                {
                    orders = "ORDER BY " + String.Join(", ", orderBy.ToArray());
                }
            }
            return orders;
        }

        public static string filter(List<Dictionary<string, string>> columns, string search, ref List<string> bindings, List<string> lsColumns)
        {
            columns.RemoveRange(lsColumns.Count(), columns.Count - lsColumns.Count());

            var globalSearch = new List<string>();
            var columnSearch = new List<string>();
            //var dtColumns = columns.Select(q => q.Keys.Where(a => a == "dt"));
            if (!string.IsNullOrEmpty(search))
            {
                var str = search;
                int ien = columns.Count();
                for (int i = 0; i < ien; i++)
                {
                    var requestColumn = columns[i];
                    var columnIdx = int.Parse(requestColumn.Where(q => q.Key == "data").FirstOrDefault().Value);
                    var column = columns[columnIdx];
                    if (requestColumn.Where(q => q.Key == "orderable").FirstOrDefault().Value == "true")
                    {
                        var binding = "'%" + str.ToUpper() + "%'";
                        bindings.Add(binding);
                        if (lsColumns[columnIdx] == "no" || lsColumns[columnIdx] == "action") continue;
                        globalSearch.Add("" + lsColumns[columnIdx] + " LIKE " + binding);
                    }
                }
            }
            // Individual column filtering
            if (columns != null)
            {
                int ien = columns.Count();
                for (int i = 0; i < ien; i++)
                {
                    var requestColumn = columns[i];
                    var columnIdx = int.Parse(requestColumn.Where(q => q.Key == "data").FirstOrDefault().Value);
                    var column = columns[columnIdx];
                    var str = requestColumn["search"];
                    if (requestColumn["searchable"] == "true" && !String.IsNullOrEmpty(str))
                    {
                        var binding = "'%" + str.ToUpper() + "%'";
                        bindings.Add(binding);
                        if (lsColumns[columnIdx] == "no" || lsColumns[columnIdx] == "action") continue;
                        globalSearch.Add("" + lsColumns[columnIdx] + " LIKE " + binding);
                    }
                }
            }
            // Combine the filters into a single string
            var where = "";
            if (globalSearch.Count() > 0)
            {
                where = '(' + string.Join(" OR ", globalSearch.ToArray()) + ')';
            }
            if (columnSearch.Count() > 0)
            {
                where = where == "" ?
                    string.Join(" AND ", columnSearch) :
                    where + " AND " + string.Join(" AND ", columnSearch);
            }
            if (!string.IsNullOrEmpty(where))
            {
                where = " AND " + where;
            }
            return where;
        }
    }
}
