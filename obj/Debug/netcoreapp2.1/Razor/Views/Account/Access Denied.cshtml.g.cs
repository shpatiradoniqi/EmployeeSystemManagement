#pragma checksum "C:\Users\shpat\source\repos\EmployeeManagment\Views\Account\Access Denied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ff16995505cea5e9cb635831b08c0ca2f2b7d6d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Access_Denied), @"mvc.1.0.view", @"/Views/Account/Access Denied.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Access Denied.cshtml", typeof(AspNetCore.Views_Account_Access_Denied))]
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
#line 1 "C:\Users\shpat\source\repos\EmployeeManagment\Views\_ViewImports.cshtml"
using EmployeeManagment.ViewModels;

#line default
#line hidden
#line 2 "C:\Users\shpat\source\repos\EmployeeManagment\Views\_ViewImports.cshtml"
using EmployeeManagment.Models;

#line default
#line hidden
#line 3 "C:\Users\shpat\source\repos\EmployeeManagment\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ff16995505cea5e9cb635831b08c0ca2f2b7d6d", @"/Views/Account/Access Denied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb61b18352ad4e70ec56c9192e4a4e739a62f5c4", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Access_Denied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 170, true);
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"text-danger\">Access Denied</h1>\r\n    <h6 class=\"text-danger\">You do not have persmission to view this resource</h6>\r\n   \r\n</div>");
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
