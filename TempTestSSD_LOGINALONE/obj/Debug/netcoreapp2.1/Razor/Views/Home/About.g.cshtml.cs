#pragma checksum "C:\Users\Daryl\Desktop\New folder (5)\TempTestSSD_LOGINALONE\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "464a398d53a2ecf381dcb6f239335864e28820e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/About.cshtml", typeof(AspNetCore.Views_Home_About))]
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
#line 1 "C:\Users\Daryl\Desktop\New folder (5)\TempTestSSD_LOGINALONE\Views\_ViewImports.cshtml"
using TempTestSSD_LOGINALONE;

#line default
#line hidden
#line 2 "C:\Users\Daryl\Desktop\New folder (5)\TempTestSSD_LOGINALONE\Views\_ViewImports.cshtml"
using TempTestSSD_LOGINALONE.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"464a398d53a2ecf381dcb6f239335864e28820e6", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90eb4fc63ad9d18046f2e43d5c7701e3472ef493", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Daryl\Desktop\New folder (5)\TempTestSSD_LOGINALONE\Views\Home\About.cshtml"
  
    ViewData["Title"] = "About";

#line default
#line hidden
            BeginContext(41, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(46, 17, false);
#line 4 "C:\Users\Daryl\Desktop\New folder (5)\TempTestSSD_LOGINALONE\Views\Home\About.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(63, 11, true);
            WriteLiteral("</h2>\r\n<h3>");
            EndContext();
            BeginContext(75, 19, false);
#line 5 "C:\Users\Daryl\Desktop\New folder (5)\TempTestSSD_LOGINALONE\Views\Home\About.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
            EndContext();
            BeginContext(94, 1284, true);
            WriteLiteral(@"</h3>

<p>
    This web application was designed as a secure and easy way to quickly check C# code for common vulnerabilities. The use of this website is restrictied to users with accounts due to the potential for mallicious behaviour with the uploading of code files and snippets.

    This website puts its users first and does so by not retaining any potential code once it has been reviewed as well as securing user accounts with minimal information and making use of auto generated usernames from emails
</p>

<br />
<br />
<h3>How to use this web application</h3>
<p>
    To first use the web application a user must first registair an account and then login their account.

    From there they will have acess to the index page and will see a file upload or a text box. Users will submit EITHER a .cs code file or a code snippet. Users cannot submit both!

    The system will analyse the code for built in known securities and provide users with a report at the end with a selection of the lines of c");
            WriteLiteral(@"ode that are vunerable and a security rating
</p>
<br />
<br />
<h3>Useage Policy</h3>
<p>
    This website may be used by individuals or corporate organizations to test code snippets. This is possible due to the code snippets not being retained.

</p>");
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
