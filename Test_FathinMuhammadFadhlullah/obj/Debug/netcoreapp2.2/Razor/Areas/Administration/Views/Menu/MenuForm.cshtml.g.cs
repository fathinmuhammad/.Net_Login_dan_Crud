#pragma checksum "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1814d2a243a79e175dc9360a125389826100d180"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_Menu_MenuForm), @"mvc.1.0.view", @"/Areas/Administration/Views/Menu/MenuForm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administration/Views/Menu/MenuForm.cshtml", typeof(AspNetCore.Areas_Administration_Views_Menu_MenuForm))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1814d2a243a79e175dc9360a125389826100d180", @"/Areas/Administration/Views/Menu/MenuForm.cshtml")]
    public class Areas_Administration_Views_Menu_MenuForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test_FathinMuhammadFadhlullah.Entities.Menu>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
  
    ViewBag.Title = "MenuForm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(139, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("page_title", async() => {
                BeginContext(163, 15, true);
                WriteLiteral("\r\n    Menu Form");
                EndContext();
            }
            );
            BeginContext(181, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(196, 70, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL CSS -->\r\n    <!-- END VIEW LEVEL CSS -->\r\n");
                EndContext();
            }
            );
            BeginContext(269, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(290, 78, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL SCRIPTS -->\r\n    <!-- END VIEW LEVEL SCRIPTS -->\r\n");
                EndContext();
            }
            );
            BeginContext(371, 90, true);
            WriteLiteral("\r\n<div class=\"page-title\"></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(462, 41, false);
#line 25 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
   Write(await Html.PartialAsync("_StatusMessage"));

#line default
#line hidden
            EndContext();
            BeginContext(503, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 26 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
         using (Html.BeginForm((Model.menu_id <= 0) ? "Add" : "Edit", "Menu", FormMethod.Post, new { @class = "form-horizontal" }))
        {
            

#line default
#line hidden
            BeginContext(662, 23, false);
#line 28 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(687, 643, true);
            WriteLiteral(@"            <div class=""portlet light bordered"">
                <div class=""portlet-title"">
                    <div class=""caption""><i class=""fa fa-cogs""></i> Menu</div>
                </div>
                <div class=""portlet-body form"">
                    <div class=""form-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Menu Name (*)</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(1331, 333, false);
#line 40 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.menu_name,
Model.menu_id <= 0 ? (object)new { id = "menu_name", maxlength = 100, @class = "form-control input-medium", placeholder = "Menu Name", @required = true } : (object)new { id = "menu_name", @class = "form-control input-medium", placeholder = "Menu Name", @required = true, @readonly = true }));

#line default
#line hidden
            EndContext();
            BeginContext(1664, 337, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Title (*)</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(2002, 164, false);
#line 47 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.menu_title, new { id = "menu_title", maxlength = 100, @class = "form-control input-large", placeholder = "Title", @required = true }));

#line default
#line hidden
            EndContext();
            BeginContext(2166, 334, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">Parent</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(2501, 214, false);
#line 53 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                                   Write(Html.DropDownListFor(model => Model.pid, new SelectList(ViewBag.listParent, "menu_id", "menu_title", Model.pid), "", new { id = "parent_id", @class = "form-control input-large", @data_placeholder = "Parent Menu" }));

#line default
#line hidden
            EndContext();
            BeginContext(2715, 347, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group form-inline"">
                                    <label class=""col-md-4 control-label"">URL (*)</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(3063, 159, false);
#line 59 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.menu_url, new { id = "menu_url", maxlength = 254, @class = "form-control input-medium", placeholder = "URL", @required = true }));

#line default
#line hidden
            EndContext();
            BeginContext(3222, 344, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group form-inline"">
                                    <label class=""col-md-4 control-label"">Icon</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(3567, 144, false);
#line 65 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.menu_icon, new { id = "menu_icon", maxlength = 100, @class = "form-control input-medium", placeholder = "Icon" }));

#line default
#line hidden
            EndContext();
            BeginContext(3711, 348, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-group form-inline"">
                                    <label class=""col-md-4 control-label"">Position</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(4060, 157, false);
#line 71 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.menu_position, new { id = "menu_position", @class = "form-control input-xsmall", @type = "number", placeholder = "Position" }));

#line default
#line hidden
            EndContext();
            BeginContext(4217, 365, true);
            WriteLiteral(@"
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
            BeginContext(4583, 37, false);
#line 81 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
                       Write(Html.Hidden("menu_id", Model.menu_id));

#line default
#line hidden
            EndContext();
            BeginContext(4620, 236, true);
            WriteLiteral("\r\n                            <button class=\"btn btn-primary\" id=\"saveFrm\" type=\"submit\" onclick=\"return confirm(\'are you sure ?\')\"><i class=\"fa fa-check icon-white\"></i> Save</button>\r\n                            <a class=\"btn default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4856, "\"", 4891, 1);
#line 83 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
WriteAttributeValue("", 4863, Url.Action("Index", "menu"), 4863, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4892, 154, true);
            WriteLiteral("><i class=\"fa fa-reply icon-white\"></i> Back</a>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 88 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\Menu\MenuForm.cshtml"
        }

#line default
#line hidden
            BeginContext(5057, 18, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Test_FathinMuhammadFadhlullah.Entities.Menu> Html { get; private set; }
    }
}
#pragma warning restore 1591
