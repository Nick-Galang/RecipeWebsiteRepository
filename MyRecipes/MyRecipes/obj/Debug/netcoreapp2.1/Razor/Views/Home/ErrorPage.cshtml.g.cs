#pragma checksum "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\Home\ErrorPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1139bfb08038195a2a43b07a6bfc974a6657b92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ErrorPage), @"mvc.1.0.view", @"/Views/Home/ErrorPage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ErrorPage.cshtml", typeof(AspNetCore.Views_Home_ErrorPage))]
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
#line 1 "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\_ViewImports.cshtml"
using MyRecipes;

#line default
#line hidden
#line 2 "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\_ViewImports.cshtml"
using MyRecipes.Models;

#line default
#line hidden
#line 3 "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\_ViewImports.cshtml"
using MyRecipes.ViewModels;

#line default
#line hidden
#line 5 "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1139bfb08038195a2a43b07a6bfc974a6657b92", @"/Views/Home/ErrorPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9368ad4a2824dc206600fe86f8ebe6bcdf36f37b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ErrorPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\Home\ErrorPage.cshtml"
  
    ViewData["Title"] = "ErrorPage";
    Layout = "_basicLayout";

#line default
#line hidden
            BeginContext(77, 108, true);
            WriteLiteral("\r\n    <div style=\"margin-top:100px;\"class=\"jumbotron text-danger\">\r\n   \r\n            <h1 style=\"color:red;\">");
            EndContext();
            BeginContext(186, 16, false);
#line 9 "C:\Backup_NIck\COMP229\MyRecipes\MyRecipes\MyRecipes\MyRecipes\Views\Home\ErrorPage.cshtml"
                              Write(ViewBag.errorMsg);

#line default
#line hidden
            EndContext();
            BeginContext(202, 154, true);
            WriteLiteral("</h1>\r\n            <p class=\"text-dark\">You don\'t have permission to update/delete any contents of the corresponding recipe.</p>\r\n        \r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
