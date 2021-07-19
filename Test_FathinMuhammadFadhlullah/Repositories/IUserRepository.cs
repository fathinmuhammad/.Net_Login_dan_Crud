using Test_FathinMuhammadFadhlullah.DTO.Ajax;
using Test_FathinMuhammadFadhlullah.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories
{
    public interface IUserRepository
    {
        List<User> search(List<string[]> param = null);
        List<User> getListActive();

        User get(int id);
        User getByUsername(string username);

        User add(User user);
        bool update(User user, string updatedUser);
        bool del(int id);

        List<UserDTO.User> getListdtTable(string wheres, string orders, string limits, List<string[]> param = null);
        int resFilterLength(string wheres, List<string[]> param = null);
        int resTotalLength(List<string[]> param = null);
    }
}
