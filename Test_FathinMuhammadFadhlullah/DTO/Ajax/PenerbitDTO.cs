using Test_FathinMuhammadFadhlullah.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;

namespace Test_FathinMuhammadFadhlullah.DTO.Ajax
{
    public class PenerbitDTO
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<Penerbit> data { get; set; }

        public class returnData
        {
            public int draw { get; set; }
            public int recordsTotal { get; set; }
            public int recordsFiltered { get; set; }
            public List<List<string>> data { get; set; }
        }

        public class Penerbit
        {
            public int no { get; set; }
            public int penerbit_id { get; set; }
            public string nama { get; set; }
            public string alamat { get; set; }
            public string created_user { get; set; }
            public DateTime? created_date { get; set; }
            public string updated_user { get; set; }
            public DateTime? updated_date { get; set; }

            public String UrlEdit
            {
                get
                {
                    var actionContext = new ActionContext(AppHttpContext.Current.Request.HttpContext, new RouteData(), new ActionDescriptor());
                    UrlHelper url = new UrlHelper(actionContext);
                    return url.Action("Edit", "Penerbit", new { id = penerbit_id });
                }
            }

            public String UrlDel
            {
                get
                {
                    var actionContext = new ActionContext(AppHttpContext.Current.Request.HttpContext, new RouteData(), new ActionDescriptor());
                    UrlHelper url = new UrlHelper(actionContext);
                    return url.Action("Delete", "Penerbit", new { id = penerbit_id });
                }
            }
        }
    }
}
