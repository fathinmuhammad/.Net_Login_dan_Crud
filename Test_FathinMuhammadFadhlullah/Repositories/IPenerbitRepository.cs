using System;
using System.Collections.Generic;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories
{
    public interface IPenerbitRepository
    {
        List<Penerbit> search(List<string[]> param = null);

        Penerbit get(int id);
        Penerbit getByName(string nama);

        Penerbit add(Penerbit penerbit);
        bool update(Penerbit penerbit);
        bool del(int id);

        List<PenerbitDTO.Penerbit> getListdtTable(string wheres, string orders, string limits, List<string[]> param = null);
        int resFilterLength(string wheres, List<string[]> param = null);
        int resTotalLength(List<string[]> param = null);
    }
}
