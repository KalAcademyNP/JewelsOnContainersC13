#pragma checksum "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc1d8c6e41fbb198a787c767f0e5c5eb291fd67e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
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
#line 1 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\_ViewImports.cshtml"
using TokenServiceAPI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc1d8c6e41fbb198a787c767f0e5c5eb291fd67e", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3f61f7d970cc795ab8bc09675f384b3df24fdbe", @"/Views/_ViewImports.cshtml")]
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiagnosticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""diagnostics-page"">
    <div class=""lead"">
        <h1>Authentication Cookie</h1>
    </div>

    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Claims</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
#line 16 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                         foreach (var claim in Model.AuthenticateResult.Principal.Claims)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>");
#nullable restore
#line 18 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                           Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\n                            <dd>");
#nullable restore
#line 19 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                           Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n");
#nullable restore
#line 20 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </dl>
                </div>
            </div>
        </div>
        
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                    <h2>Properties</h2>
                </div>
                <div class=""card-body"">
                    <dl>
");
#nullable restore
#line 33 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                         foreach (var prop in Model.AuthenticateResult.Properties.Items)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>");
#nullable restore
#line 35 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                           Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\n                            <dd>");
#nullable restore
#line 36 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                           Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n");
#nullable restore
#line 37 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                         if (Model.Clients.Any())
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <dt>Clients</dt>\n                            <dd>\n");
#nullable restore
#line 42 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                              
                                var clients = Model.Clients.ToArray();
                                for(var i = 0; i < clients.Length; i++)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                                     Write(clients[i]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                                                            
                                    if (i < clients.Length - 1)
                                    {
                                        

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 49 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                                                       
                                    }
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </dd>\n");
#nullable restore
#line 54 "G:\Github\SWC12\JewelsOnContainers\TokenServiceAPI\Views\Diagnostics\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </dl>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiagnosticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
