using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Utils
{
    public static class UrlExtensions
    {
        public static string AbsoluteContent(string contentPath)
        {
            // Build a URI for the requested path
            var url = new Uri($"{ AppHttpContext.Current.Request.Scheme }://{AppHttpContext.Current.Request.Host}/{contentPath}"); //new Uri(new Uri(AppHttpContext.Current.Request.Host,), contentPath);
            // Return the absolute UrI
            return url.AbsoluteUri;
        }
    }
}
