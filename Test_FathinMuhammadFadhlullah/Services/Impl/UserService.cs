using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Exceptions;
using Test_FathinMuhammadFadhlullah.Repositories;
using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Services.Impl
{
    public class UserService : IUserService
    {
        protected IUserRepository userRepo;
        private IHttpContextAccessor http;

        public UserService(IUserRepository userRepo, IHttpContextAccessor accessor)
        {
            this.userRepo = userRepo;
            http = accessor;
        }

        public User add(User user)
        {
            userRepo.add(user);
            return user;
        }

        public bool del(int id)
        {
            bool result = false;
            try
            {
                userRepo.del(id);
                result = true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public User get(int id)
        {
            return userRepo.get(id);
        }

        public User getByUsername(string username)
        {
            return userRepo.getByUsername(username);
        }

        public User login(string username, string pass)
        {
            User tmp = userRepo.getByUsername(username);

            if (tmp != null)
            {
                AES aES = new AES();
                string hashedPassword = aES.Encrypt("USR", pass);

                if (hashedPassword == tmp.password)
                {
                    userRepo.update(tmp, tmp.username);

                    return tmp;
                }
                else
                    throw new WrongPasswordException();
            }
            else
                throw new UserNotFoundException();

        }

        public bool logout(string user_id)
        {
            throw new NotImplementedException();
        }

        public List<User> search(List<string[]> param = null)
        {
            List<User> result = userRepo.search(param);

            return result;
        }

        public bool update(User user)
        {
            bool result = false;
            if (userRepo.update(user, "")) result = true;

            return result;
        }

        public List<User> getListActive()
        {
            return userRepo.getListActive();
        }
    }
}
