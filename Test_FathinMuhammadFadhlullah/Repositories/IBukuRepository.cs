using System;
using System.Collections.Generic;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories
{
    public interface IBukuRepository
    {
        List<Buku> search(List<string[]> param = null);

        Buku get(int id);
        Buku getByJudul(string judul);

        Buku add(Buku buku);
        bool update(Buku buku);
        bool del(int id);

        List<BukuDTO.Buku> getListdtTable(string wheres, string orders, string limits, List<string[]> param = null);
        int resFilterLength(string wheres, List<string[]> param = null);
        int resTotalLength(List<string[]> param = null);
    }
}
