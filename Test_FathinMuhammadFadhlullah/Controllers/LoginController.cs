using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Test_FathinMuhammadFadhlullah.Exceptions;
using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Services;
using Test_FathinMuhammadFadhlullah.Utils;

namespace Test_FathinMuhammadFadhlullah.Controllers
{
    public class LoginController : Controller
    {
        protected IUserService repo;

        public LoginController(IUserService _repo)
        {
            repo = _repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User model, string returnUrl)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // check login via local user / api
                User user = new User();

                user = repo.login(model.username, model.password);

                if (user != null)
                {
                    // assign session
                    AppHttpContext.Current.Session.SetString("user_id", user.user_id.ToString());
                    AppHttpContext.Current.Session.SetString("username", user.username);
                    AppHttpContext.Current.Session.SetString("fullname", user.fullname);
                    AppHttpContext.Current.Session.SetString("usergroup_id", user.usergroup_id.ToString());
                    AppHttpContext.Current.Session.SetString("usergroup_name", user.usergroup_name);

                    return RedirectToAction("Index", "Home");
                }

            }
            catch (UserNotFoundException)
            {
                ModelState.AddModelError("", "User not found");
            }
            catch (WrongPasswordException)
            {
                ModelState.AddModelError("", "Wrong password");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                AppHttpContext.Current.Session.Clear();
            }

            return View("Index", model);
        }

        public ActionResult Logout()
        {
            AppHttpContext.Current.Session.Clear();
            //AppHttpContext.Current.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            //AppHttpContext.Current.Response.Headers.Add("Pragma", "no-cache");
            //AppHttpContext.Current.Response.Headers.Add("Expires", "0");
            return RedirectToAction("Index", "Login");
        }
    }
}