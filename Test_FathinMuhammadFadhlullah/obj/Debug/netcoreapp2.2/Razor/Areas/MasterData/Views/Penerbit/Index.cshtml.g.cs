#pragma checksum "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b62105ba94be3dc953c9e68281adbe1525344fe9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MasterData_Views_Penerbit_Index), @"mvc.1.0.view", @"/Areas/MasterData/Views/Penerbit/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/MasterData/Views/Penerbit/Index.cshtml", typeof(AspNetCore.Areas_MasterData_Views_Penerbit_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b62105ba94be3dc953c9e68281adbe1525344fe9", @"/Areas/MasterData/Views/Penerbit/Index.cshtml")]
    public class Areas_MasterData_Views_Penerbit_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Test_FathinMuhammadFadhlullah.Entities.Penerbit>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(148, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("page_title", async() => {
                BeginContext(170, 19, true);
                WriteLiteral("\r\n    Penerbit Data");
                EndContext();
            }
            );
            BeginContext(192, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(207, 70, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL CSS -->\r\n    <!-- END VIEW LEVEL CSS -->\r\n");
                EndContext();
            }
            );
            BeginContext(280, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(301, 78, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL SCRIPTS -->\r\n    <!-- END VIEW LEVEL SCRIPTS -->\r\n");
                EndContext();
            }
            );
            BeginContext(382, 90, true);
            WriteLiteral("\r\n<div class=\"page-title\"></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(473, 41, false);
#line 25 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml"
   Write(await Html.PartialAsync("_StatusMessage"));

#line default
#line hidden
            EndContext();
            BeginContext(514, 960, true);
            WriteLiteral(@"
        <!-- start filter -->
        <div class=""portlet light bordered"">
            <div class=""portlet-title"">
                <div class=""caption"">
                    <i class=""fa fa-filter font-green""></i>
                    <span class=""caption-subject font-green bold uppercase""> Filter Penerbit</span>
                </div>
                <div class=""tools""></div>
            </div>
            <div class=""portlet-body form"">
                <div class=""form-horizontal"">
                    <div class=""form-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Nama</label>
                                    <div class=""col-md-8"">
                                        <input type=""text"" class=""form-control input-medium"" id=""nama"" name=""nama""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1474, "\"", 1513, 1);
#line 43 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml"
WriteAttributeValue("", 1482, ViewBag.nama ?? String.Empty, 1482, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1514, 413, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Alamat</label>
                                    <div class=""col-md-8"">
                                        <input type=""text"" class=""form-control input-medium"" id=""alamat"" name=""alamat""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1927, "\"", 1968, 1);
#line 49 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml"
WriteAttributeValue("", 1935, ViewBag.alamat ?? String.Empty, 1935, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1969, 1279, true);
            WriteLiteral(@">
                                    </div>
                                </div>
                            </div>
                            <div class=""col-md-5"">
                                <div class=""form-group"">
                                    <label class=""col-md-2 control-label""></label>
                                    <div class=""col-md-8"">
                                        <button class=""btn btn-primary"" id=""submitPenerbit"" name=""submit"" value=""findDoc""><i class=""fa fa-search""></i> Search</button> &nbsp; &nbsp;
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
");
            WriteLiteral("                        <span class=\"caption-subject bold uppercase\"> Penerbit</span>\r\n                    </div>\r\n                    <div class=\"actions\">\r\n                        <div class=\"btn-group btn-group-devided\">\r\n                            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3248, "\"", 3284, 1);
#line 74 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml"
WriteAttributeValue("", 3255, Url.Action("Add","Penerbit"), 3255, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3285, 373, true);
            WriteLiteral(@" class=""btn btn-circle btn-sm sbold red"">
                                <i class=""fa fa-plus""> </i>Add New
                            </a>
                        </div>
                    </div>
                </div>
                <div class=""portlet-body"">
                    <table class=""table table-striped table-bordered table-hover"" data-request-url=""");
            EndContext();
            BeginContext(3659, 37, false);
#line 81 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Penerbit\Index.cshtml"
                                                                                               Write(Url.Action("IndexSearch", "Penerbit"));

#line default
#line hidden
            EndContext();
            BeginContext(3696, 574, true);
            WriteLiteral(@""" id=""dtTables"">
                        <thead>
                            <tr role=""row"">
                                <th>No.</th>
                                <th>Nama</th>
                                <th>Alamat</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>

                        </tbody>
                    </table>
                </div>
            </div>
            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Test_FathinMuhammadFadhlullah.Entities.Penerbit>> Html { get; private set; }
    }
}
#pragma warning restore 1591