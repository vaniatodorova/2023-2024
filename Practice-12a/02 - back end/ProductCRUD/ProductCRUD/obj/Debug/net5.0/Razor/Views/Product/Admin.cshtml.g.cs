#pragma checksum "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0397b482aa38d6d02b256d953aab779778a0290f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Admin), @"mvc.1.0.view", @"/Views/Product/Admin.cshtml")]
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
#line 1 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\_ViewImports.cshtml"
using ProductCRUD;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\_ViewImports.cshtml"
using ProductCRUD.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0397b482aa38d6d02b256d953aab779778a0290f", @"/Views/Product/Admin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b89524d63699a8e9582b2fad74a9b9adfa26694", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Admin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductCRUD.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
  
    ViewBag.Title = "Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Admin</h2>\r\n    <p>\r\n        ");
#nullable restore
#line 9 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
   Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n<table class=\"table table-hover\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 14 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 17 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 20 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
       Write(Html.DisplayNameFor(model => model.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 23 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
       Write(Html.DisplayNameFor(model => model.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 28 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 885, "\"", 915, 1);
#nullable restore
#line 38 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
WriteAttributeValue("", 891, Url.Content(item.Image), 891, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" art=\"Not Found\" width=\"80\" height=\"80\" />\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cost));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                    ");
#nullable restore
#line 44 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 45 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.Id }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 46 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { id = item.Id }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 49 "E:\2023-2024 REPOSITORY\Practice-12a\02 - back end\ProductCRUD\ProductCRUD\Views\Product\Admin.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductCRUD.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
