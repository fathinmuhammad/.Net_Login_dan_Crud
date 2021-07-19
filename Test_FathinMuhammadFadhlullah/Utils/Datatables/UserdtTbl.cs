using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using Test_FathinMuhammadFadhlullah.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Utils.Datatables
{
    public class UserdtTbl
    {
        public IUserRepository _ISRepo;

        public UserdtTbl(IUserRepository ISRepo)
        {
            _ISRepo = ISRepo;
        }

        public UserDTO simple(int start, int length, IEnumerable<Dictionary<string, string>> ordr, string serch, IEnumerable<Dictionary<string, string>> columns, List<string> lsColumns, List<string[]> param = null)
        {
            UserDTO result = new UserDTO();

            var bindings = new List<string>();
            var limits = datatables.limit(start, length, columns.ToList());
            var orders = datatables.order(ordr.ToList(), columns.ToList(), lsColumns);
            var wheres = datatables.filter(columns.ToList(), serch, ref bindings, lsColumns);

            var data = _ISRepo.getListdtTable(wheres, orders, limits, param);

            int resFilterLength = _ISRepo.resFilterLength(wheres, param);
            var recordsFiltered = resFilterLength;
            int recordsTotal = _ISRepo.resTotalLength(param);
            result.data = data;
            result.recordsFiltered = recordsFiltered;
            result.recordsTotal = recordsTotal;

            return result;
        }
    }
}
