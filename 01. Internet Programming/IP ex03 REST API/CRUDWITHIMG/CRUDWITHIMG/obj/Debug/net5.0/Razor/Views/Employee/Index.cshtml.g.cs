#pragma checksum "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df5473f8757c61659ba63878a700618f20978df3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index), @"mvc.1.0.view", @"/Views/Employee/Index.cshtml")]
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
#nullable restore
#line 1 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\_ViewImports.cshtml"
using CRUDWITHIMG;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\_ViewImports.cshtml"
using CRUDWITHIMG.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df5473f8757c61659ba63878a700618f20978df3", @"/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7cb80d10952a4ace94a53a8ba3f9d4f180f9200", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CRUDWITHIMG.Models.Employeemaster>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Index</h2>\r\n");
#nullable restore
#line 8 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
 if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        ");
#nullable restore
#line 11 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
   Write(Html.ActionLink("Create New", "Create", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 13 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table table-hover table\">\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Empcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Empname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Designation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Empimg));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 34 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Empcode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Empname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Designation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Salary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1444, "\"", 1475, 1);
#nullable restore
#line 50 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
WriteAttributeValue("", 1450, Url.Content(item.Empimg), 1450, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" art=\"Not Found\" width=\"80\" height=\"80\" />\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 53 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
                     if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
                                                                                                                  
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 57 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
               Write(Html.ActionLink("Details", "Details", new { id = item.Id }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 58 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
                     if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
                                                                                                                     
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 64 "E:\2023-2024 REPOSITORY\01. Internet Programming\IP ex03 REST API\CRUDWITHIMG\CRUDWITHIMG\Views\Employee\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CRUDWITHIMG.Models.Employeemaster>> Html { get; private set; }
    }
}
#pragma warning restore 1591
