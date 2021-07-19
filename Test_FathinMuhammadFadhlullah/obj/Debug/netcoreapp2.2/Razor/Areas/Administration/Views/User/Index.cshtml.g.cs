#pragma checksum "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b48657185ced9c25047ab99f8222717ac8d0c97"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_User_Index), @"mvc.1.0.view", @"/Areas/Administration/Views/User/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administration/Views/User/Index.cshtml", typeof(AspNetCore.Areas_Administration_Views_User_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b48657185ced9c25047ab99f8222717ac8d0c97", @"/Areas/Administration/Views/User/Index.cshtml")]
    public class Areas_Administration_Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Test_FathinMuhammadFadhlullah.Entities.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(144, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("page_title", async() => {
                BeginContext(166, 30, true);
                WriteLiteral("\r\n    User Administration Data");
                EndContext();
            }
            );
            BeginContext(199, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(214, 70, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL CSS -->\r\n    <!-- END VIEW LEVEL CSS -->\r\n");
                EndContext();
            }
            );
            BeginContext(287, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(308, 78, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL SCRIPTS -->\r\n    <!-- END VIEW LEVEL SCRIPTS -->\r\n");
                EndContext();
            }
            );
            BeginContext(389, 90, true);
            WriteLiteral("\r\n<div class=\"page-title\"></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(480, 41, false);
#line 25 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml"
   Write(await Html.PartialAsync("_StatusMessage"));

#line default
#line hidden
            EndContext();
            BeginContext(521, 968, true);
            WriteLiteral(@"
        <!-- start filter -->
        <div class=""portlet light bordered"">
            <div class=""portlet-title"">
                <div class=""caption"">
                    <i class=""fa fa-filter font-green""></i>
                    <span class=""caption-subject font-green bold uppercase""> Filter User</span>
                </div>
                <div class=""tools""></div>
            </div>
            <div class=""portlet-body form"">
                <div class=""form-horizontal"">
                    <div class=""form-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Username</label>
                                    <div class=""col-md-8"">
                                        <input type=""text"" class=""form-control input-medium"" id=""username"" name=""username""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1489, "\"", 1532, 1);
#line 43 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml"
WriteAttributeValue("", 1497, ViewBag.username ?? String.Empty, 1497, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1533, 419, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Fullname</label>
                                    <div class=""col-md-8"">
                                        <input type=""text"" class=""form-control input-medium"" id=""fullname"" name=""fullname""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1952, "\"", 1995, 1);
#line 49 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml"
WriteAttributeValue("", 1960, ViewBag.fullname ?? String.Empty, 1960, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1996, 1230, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-5"">
                                <div class=""form-group"">
                                    <label class=""col-md-2 control-label""></label>
                                    <div class=""col-md-8"">
                                        <button class=""btn btn-primary"" id=""submitUsr"" name=""submit"" value=""findDoc""><i class=""fa fa-search""></i> Search</button> &nbsp; &nbsp;
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <!-- end of filter -->
        <div class=""portlet light "">
            <div class=""portlet-title"">
                <div class=""caption font-dark"">
                    <i class=""icon-settings font-dark""></i>
                    <span");
            WriteLiteral(" class=\"caption-subject bold uppercase\"> User</span>\r\n                </div>\r\n                <div class=\"actions\">\r\n                    <div class=\"btn-group btn-group-devided\">\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3226, "\"", 3258, 1);
#line 74 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml"
WriteAttributeValue("", 3233, Url.Action("Add","User"), 3233, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3259, 345, true);
            WriteLiteral(@" class=""btn btn-circle btn-sm sbold red"">
                            <i class=""fa fa-plus""> </i>Add New
                        </a>
                    </div>
                </div>
            </div>
            <div class=""portlet-body"">
                <table class=""table table-striped table-bordered table-hover"" data-request-url=""");
            EndContext();
            BeginContext(3605, 33, false);
#line 81 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\User\Index.cshtml"
                                                                                           Write(Url.Action("IndexSearch", "User"));

#line default
#line hidden
            EndContext();
            BeginContext(3638, 359, true);
            WriteLiteral(@""" id=""dtTables"">
                    <thead>
                        <tr role=""row"">
                            <th>No.</th>
                            <th>Username</th>
                            <th>FullName</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
            BeginContext(4955, 153, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <!-- END EXAMPLE TABLE PORTLET-->\r\n    </div>\r\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Test_FathinMuhammadFadhlullah.Entities.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
