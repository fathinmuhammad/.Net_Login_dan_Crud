#pragma checksum "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf7edfa508aa4268a0dba9b15fd20c54f6ff4823"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MasterData_Views_Buku_BukuForm), @"mvc.1.0.view", @"/Areas/MasterData/Views/Buku/BukuForm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/MasterData/Views/Buku/BukuForm.cshtml", typeof(AspNetCore.Areas_MasterData_Views_Buku_BukuForm))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf7edfa508aa4268a0dba9b15fd20c54f6ff4823", @"/Areas/MasterData/Views/Buku/BukuForm.cshtml")]
    public class Areas_MasterData_Views_Buku_BukuForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test_FathinMuhammadFadhlullah.Entities.Buku>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
  
    ViewBag.Title = "BukuForm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(139, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("page_title", async() => {
                BeginContext(161, 20, true);
                WriteLiteral("\r\n    Form Data Buku");
                EndContext();
            }
            );
            BeginContext(184, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(199, 70, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL CSS -->\r\n    <!-- END VIEW LEVEL CSS -->\r\n");
                EndContext();
            }
            );
            BeginContext(272, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(293, 78, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL SCRIPTS -->\r\n    <!-- END VIEW LEVEL SCRIPTS -->\r\n");
                EndContext();
            }
            );
            BeginContext(374, 90, true);
            WriteLiteral("\r\n<div class=\"page-title\"></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(465, 41, false);
#line 24 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
   Write(await Html.PartialAsync("_StatusMessage"));

#line default
#line hidden
            EndContext();
            BeginContext(506, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 25 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
         using (Html.BeginForm((Model.buku_id <= 0) ? "Add" : "Edit", "Buku", FormMethod.Post, new { @class = "form-horizontal" }))
        {
            

#line default
#line hidden
            BeginContext(665, 23, false);
#line 27 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(690, 325, true);
            WriteLiteral(@"            <div class=""portlet light bordered"">
                <div class=""portlet-title"">
                    <div class=""caption""><i class=""fa fa-cogs""></i> Buku</div>
                    <div class=""actions"">
                        <a name=""TransInfo"" id=""TransInfo"" class=""btn btn-circle btn-icon-only btn-default""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1015, "\"", 1058, 3);
            WriteAttributeValue("", 1025, "transInfo(\'BKU\',", 1025, 16, true);
#line 32 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
WriteAttributeValue(" ", 1041, Model.buku_id, 1042, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 1056, ");", 1056, 2, true);
            EndWriteAttribute();
            BeginContext(1059, 600, true);
            WriteLiteral(@" href=""#myModalTransInfo"" data-toggle=""modal"" data-backdrop=""static""><i class=""fa fa-info-circle""></i></a>
                    </div>
                </div>
                <div class=""portlet-body form"">
                    <div class=""form-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Judul (*)</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(1660, 142, false);
#line 42 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.judul, new { id = "judul", @class = "form-control input-large", placeholder = "Judul Buku", @required = true }));

#line default
#line hidden
            EndContext();
            BeginContext(1802, 340, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Penerbit (*)</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(2143, 295, false);
#line 48 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
                                   Write(Html.DropDownListFor(model => Model.penerbit_id, new SelectList(ViewBag.listPenerbit, "penerbit_id", "nama", ViewBag.listPenerbit), "", new { id = "penerbit_id", @class = "form-control input-large select2", @data_tags = "true", @data_placeholder = "Pilih Penerbit", @data_allow_clear = "true" }));

#line default
#line hidden
            EndContext();
            BeginContext(2438, 479, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Date Purchase Contract *</label>
                                    <div class=""col-md-8"">
                                        <div class=""col-md-6 input-group date date-picker"" data-date-format=""dd-mm-yyyy"">
                                            ");
            EndContext();
            BeginContext(2918, 183, false);
#line 55 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
                                       Write(Html.TextBoxFor(model => Model.tanggal_terbit, new { @Value = Model.tanggal_terbit.ToString("dd-MM-yyyy"), @class = "form-control form-filter", placeholder = "To", @required = true }));

#line default
#line hidden
            EndContext();
            BeginContext(3101, 787, true);
            WriteLiteral(@"
                                            <span class=""input-group-btn"">
                                                <button class=""btn btn-small default"" type=""button"">
                                                    <i class=""fa fa-calendar""></i>
                                                </button>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""form-actions"">
                    <div class=""row"">
                        <div class=""col-md-6"">
                            ");
            EndContext();
            BeginContext(3889, 37, false);
#line 71 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
                       Write(Html.Hidden("buku_id", Model.buku_id));

#line default
#line hidden
            EndContext();
            BeginContext(3926, 229, true);
            WriteLiteral("\r\n                            <button class=\"btn blue\" id=\"saveFrm\" type=\"submit\" onclick=\"return confirm(\'are you sure ?\')\"><i class=\"fa fa-check icon-white\"></i> Save</button>\r\n                            <a class=\"btn default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4155, "\"", 4190, 1);
#line 73 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
WriteAttributeValue("", 4162, Url.Action("Index", "Buku"), 4162, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4191, 154, true);
            WriteLiteral("><i class=\"fa fa-reply icon-white\"></i> Back</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 78 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\MasterData\Views\Buku\BukuForm.cshtml"
        }

#line default
#line hidden
            BeginContext(4356, 18, true);
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Test_FathinMuhammadFadhlullah.Entities.Buku> Html { get; private set; }
    }
}
#pragma warning restore 1591