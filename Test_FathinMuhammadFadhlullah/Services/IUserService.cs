using Test_FathinMuhammadFadhlullah.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Services
{
    public interface IUserService
    {
        User login(string user_id, string pass);
        bool logout(string user_id);

        List<User> search(List<string[]> param = null);
        List<User> getListActive();

        User get(int id);
        User getByUsername(string username);

        User add(User user);
        bool update(User user);
        bool del(int id);
    }
}
