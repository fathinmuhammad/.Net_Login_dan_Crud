#pragma checksum "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2a4b736cea96ffa7c68c0b4fd5387adb13ead0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administration_Views_UserGroup_UserGroupForm), @"mvc.1.0.view", @"/Areas/Administration/Views/UserGroup/UserGroupForm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Administration/Views/UserGroup/UserGroupForm.cshtml", typeof(AspNetCore.Areas_Administration_Views_UserGroup_UserGroupForm))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2a4b736cea96ffa7c68c0b4fd5387adb13ead0f", @"/Areas/Administration/Views/UserGroup/UserGroupForm.cshtml")]
    public class Areas_Administration_Views_UserGroup_UserGroupForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Test_FathinMuhammadFadhlullah.Entities.UserGroup>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
  
    ViewBag.Title = "UserGroupForm";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(149, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("page_title", async() => {
                BeginContext(171, 21, true);
                WriteLiteral("\r\n    User Group Form");
                EndContext();
            }
            );
            BeginContext(195, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("css", async() => {
                BeginContext(210, 70, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL CSS -->\r\n    <!-- END VIEW LEVEL CSS -->\r\n");
                EndContext();
            }
            );
            BeginContext(283, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(304, 78, true);
                WriteLiteral("\r\n    <!-- BEGIN VIEW LEVEL SCRIPTS -->\r\n    <!-- END VIEW LEVEL SCRIPTS -->\r\n");
                EndContext();
            }
            );
            BeginContext(385, 90, true);
            WriteLiteral("\r\n<div class=\"page-title\"></div>\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        ");
            EndContext();
            BeginContext(476, 30, false);
#line 24 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
   Write(Html.Partial("_StatusMessage"));

#line default
#line hidden
            EndContext();
            BeginContext(506, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 25 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
         using (Html.BeginForm((Model.usergroup_id <= 0) ? "Add" : "Edit", "UserGroup", FormMethod.Post, new { @class = "form-horizontal" }))
        {
            

#line default
#line hidden
            BeginContext(675, 23, false);
#line 27 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(700, 330, true);
            WriteLiteral(@"            <div class=""portlet light bordered"">
                <div class=""portlet-title"">
                    <div class=""caption""><i class=""fa fa-cogs""></i> UserGroup</div>
                    <div class=""actions"">
                        <a name=""TransInfo"" id=""TransInfo"" class=""btn btn-circle btn-icon-only btn-default""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1030, "\"", 1079, 3);
            WriteAttributeValue("", 1040, "transInfo(\'USRG\',", 1040, 17, true);
#line 32 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
WriteAttributeValue(" ", 1057, Model.usergroup_id, 1058, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 1077, ");", 1077, 2, true);
            EndWriteAttribute();
            BeginContext(1080, 606, true);
            WriteLiteral(@" href=""#myModalTransInfo"" data-toggle=""modal"" data-backdrop=""static""><i class=""fa fa-info-circle""></i></a>
                    </div>
                </div>
                <div class=""portlet-body form"">
                    <div class=""form-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <div class=""form-group"">
                                    <label class=""col-md-4 control-label"">User Group Name</label>
                                    <div class=""col-md-8"">
                                        ");
            EndContext();
            BeginContext(1687, 165, false);
#line 42 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
                                   Write(Html.TextBoxFor(model => Model.usergroup_name, new { id = "usergroup_name", @class = "form-control input-medium", placeholder = "Usergroup Name", @required = true }));

#line default
#line hidden
            EndContext();
            BeginContext(1852, 359, true);
            WriteLiteral(@"
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
            BeginContext(2212, 47, false);
#line 52 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
                           Write(Html.Hidden("usergroup_id", Model.usergroup_id));

#line default
#line hidden
            EndContext();
            BeginContext(2259, 200, true);
            WriteLiteral("\r\n                                <button class=\"btn grey-salsa\" id=\"saveFrm\" type=\"submit\"><i class=\"fa fa-check icon-white\"></i> Save</button>\r\n                                <a class=\"btn default\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2459, "\"", 2499, 1);
#line 54 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
WriteAttributeValue("", 2466, Url.Action("Index", "usergroup"), 2466, 33, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2500, 190, true);
            WriteLiteral("><i class=\"fa fa-reply icon-white\"></i> Back</a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 60 "D:\SysProject\Test_FathinMuhammadFadhlullah\Test_FathinMuhammadFadhlullah\Areas\Administration\Views\UserGroup\UserGroupForm.cshtml"
        }

#line default
#line hidden
            BeginContext(2701, 18, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Test_FathinMuhammadFadhlullah.Entities.UserGroup> Html { get; private set; }
    }
}
#pragma warning restore 1591