using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Test_FathinMuhammadFadhlullah.Utils
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = filterContext.HttpContext;
            if (context.Session != null)
            {
                if (context.Session.GetString("user_id") == null)
                {
                    //string sessionCookie = context.Request.Headers["Cookie"];
                    //if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET&#95;SessionId") >= 0))
                    //{
                    //    string redirectTo = "/Login";
                    //    if (!string.IsNullOrEmpty(context.Request.Path.Value))
                    //    {
                    //        redirectTo = string.Format("/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.Path.Value));
                    //    }
                    //    filterContext.HttpContext.Response.Redirect(redirectTo, true);
                    //}
                    //else
                    //{
                        filterContext.Result = new RedirectResult(url: "/Login"//, permanent: true,
                             //preserveMethod: true
                             );
                        //new RedirectToRouteResult(new RouteValueDictionary(
                        //        new
                        //        {
                        //            //area="./",
                        //            controller = "Login",
                        //            action = "Index"
                        //        })); 
                    //}
                }
            }
            base.OnActionExecuting(filterContext);
        }

        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    //Log("OnActionExecuted", filterContext.RouteData);
        //}

        //public override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //    //Log("OnResultExecuting", filterContext.RouteData);
        //}

        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    //Log("OnResultExecuted", filterContext.RouteData);
        //}
    }
}
