#pragma checksum "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a10ff80f97cbfe3b83714a3a158564a9000a4f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Menu_Index), @"mvc.1.0.view", @"/Areas/Administration/Views/Menu/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administration/Views/Menu/Index.cshtml", typeof(AspNetCore.Areas_Administration_Views_Menu_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a10ff80f97cbfe3b83714a3a158564a9000a4f5", @"/Areas/Administration/Views/Menu/Index.cshtml")]
    public class Areas_Administration_Views_Menu_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Test_FathinMuhammadFadhlullah.Entities.Menu>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(142, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("page_title", async() => {
                BeginContext(166, 22, true);
                WriteLiteral("\r\n    Menu Master Data");
                EndContext();
            }
            );
            BeginContext(191, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(206, 70, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL CSS -->\r\n    <!-- END VIEW LEVEL CSS -->\r\n");
                EndContext();
            }
            );
            BeginContext(279, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(300, 78, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL SCRIPTS -->\r\n    <!-- END VIEW LEVEL SCRIPTS -->\r\n");
                EndContext();
            }
            );
            BeginContext(381, 90, true);
            WriteLiteral("\r\n<div class=\"page-title\"></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(472, 41, false);
#line 25 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
   Write(await Html.PartialAsync("_StatusMessage"));

#line default
#line hidden
            EndContext();
            BeginContext(513, 422, true);
            WriteLiteral(@"
        <div class=""portlet light "">
            <div class=""portlet-title"">
                <div class=""caption font-dark"">
                    <i class=""icon-settings font-dark""></i>
                    <span class=""caption-subject bold uppercase""> Menu</span>
                </div>
                <div class=""actions"">
                    <div class=""btn-group btn-group-devided"">
                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 935, "\"", 967, 1);
#line 34 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
WriteAttributeValue("", 942, Url.Action("Add","Menu"), 942, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(968, 776, true);
            WriteLiteral(@" class=""btn btn-circle btn-sm sbold red"">
                            <i class=""fa fa-plus""> </i>Add New
                        </a>
                    </div>
                </div>
            </div>
            <div class=""portlet-body"">
                <table class=""table table-striped table-bordered table-hover"" id=""datatables"">
                    <thead>
                        <tr role=""row"">
                            <th>Menu Name</th>
                            <th>Title</th>
                            <th>URL</th>
                            <th>Icon</th>
                            <th>Sort Order</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 53 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                          
                            for (int i = 0; i < Model.Count; i++)
                            {

#line default
#line hidden
            BeginContext(1870, 78, true);
            WriteLiteral("                                <tr>\r\n                                    <td>");
            EndContext();
            BeginContext(1949, 18, false);
#line 57 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                                   Write(Model[i].menu_name);

#line default
#line hidden
            EndContext();
            BeginContext(1967, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2015, 19, false);
#line 58 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                                   Write(Model[i].menu_title);

#line default
#line hidden
            EndContext();
            BeginContext(2034, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2082, 17, false);
#line 59 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                                   Write(Model[i].menu_url);

#line default
#line hidden
            EndContext();
            BeginContext(2099, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2147, 18, false);
#line 60 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                                   Write(Model[i].menu_icon);

#line default
#line hidden
            EndContext();
            BeginContext(2165, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(2213, 22, false);
#line 61 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                                   Write(Model[i].menu_position);

#line default
#line hidden
            EndContext();
            BeginContext(2235, 91, true);
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2326, "\"", 2392, 1);
#line 63 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
WriteAttributeValue("", 2333, Url.Action("Edit","Menu", new { code = Model[i].menu_id }), 2333, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2393, 122, true);
            WriteLiteral(" class=\"icon huge\" title=\"Details Menu\"><i class=\"fa fa-pencil\"></i></a>&nbsp;\r\n                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2515, "\"", 2583, 1);
#line 64 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
WriteAttributeValue("", 2522, Url.Action("Delete","Menu", new { code = Model[i].menu_id }), 2522, 61, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2584, 199, true);
            WriteLiteral(" class=\"icon huge\" title=\"Delete Menu\" onclick=\"return confirm(\'are you sure ?\')\"><i class=\"fa fa-trash-o\"></i></a>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 67 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\Index.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(2841, 155, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <!-- END EXAMPLE TABLE PORTLET-->\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Test_FathinMuhammadFadhlullah.Entities.Menu>> Html { get; private set; }
    }
}
#pragma warning restore 1591
