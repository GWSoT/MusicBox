#pragma checksum "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99f7ea0ea9e804d216f8e372f7a34f0101f920cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
#line 1 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\_ViewImports.cshtml"
using AuthServer;

#line default
#line hidden
#line 2 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\_ViewImports.cshtml"
using AuthServer.Data;

#line default
#line hidden
#line 3 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\_ViewImports.cshtml"
using AuthServer.ViewModels;

#line default
#line hidden
#line 4 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99f7ea0ea9e804d216f8e372f7a34f0101f920cd", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c7a0e5f7a42d021db4a11839606334175af25fc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(23, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
            BeginContext(66, 114, true);
            WriteLiteral("\r\n\r\n<div class=\"jumbotron\">\r\n    <h2>Ooooops, something went really bad! :(</h2>\r\n    <p class=\"lead text-left\">\r\n");
            EndContext();
#line 11 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
         if (!string.IsNullOrEmpty(Model.Error))
        {

#line default
#line hidden
            BeginContext(241, 20, true);
            WriteLiteral("            <strong>");
            EndContext();
            BeginContext(262, 11, false);
#line 13 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
               Write(Model.Error);

#line default
#line hidden
            EndContext();
            BeginContext(273, 11, true);
            WriteLiteral("</strong>\r\n");
            EndContext();
#line 14 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
        }

#line default
#line hidden
            BeginContext(295, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
         if (!string.IsNullOrEmpty(Model.ErrorDescription))
        {

#line default
#line hidden
            BeginContext(369, 19, true);
            WriteLiteral("            <small>");
            EndContext();
            BeginContext(389, 22, false);
#line 18 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
              Write(Model.ErrorDescription);

#line default
#line hidden
            EndContext();
            BeginContext(411, 10, true);
            WriteLiteral("</small>\r\n");
            EndContext();
#line 19 "C:\Users\rainman\source\repos\MusicBox\AuthServer\Views\Shared\Error.cshtml"
        }

#line default
#line hidden
            BeginContext(432, 16, true);
            WriteLiteral("    </p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591