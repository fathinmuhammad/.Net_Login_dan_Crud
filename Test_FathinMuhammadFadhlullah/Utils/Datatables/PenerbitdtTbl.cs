using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using Test_FathinMuhammadFadhlullah.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Utils.Datatables
{
    public class PenerbitdtTbl
    {
        public IPenerbitRepository _Repo;

        public PenerbitdtTbl(IPenerbitRepository Repo)
        {
            _Repo = Repo;
        }

        public PenerbitDTO simple(int start, int length, IEnumerable<Dictionary<string, string>> ordr, string serch, IEnumerable<Dictionary<string, string>> columns, List<string> lsColumns, List<string[]> param = null)
        {
            PenerbitDTO result = new PenerbitDTO();

            var bindings = new List<string>();
            var limits = datatables.limit(start, length, columns.ToList());
            var orders = datatables.order(ordr.ToList(), columns.ToList(), lsColumns);
            var wheres = datatables.filter(columns.ToList(), serch, ref bindings, lsColumns);

            var data = _Repo.getListdtTable(wheres, orders, limits, param);

            int resFilterLength = _Repo.resFilterLength(wheres, param);
            var recordsFiltered = resFilterLength;
            int recordsTotal = _Repo.resTotalLength(param);
            result.data = data;
            result.recordsFiltered = recordsFiltered;
            result.recordsTotal = recordsTotal;

            return result;
        }
    }
}
