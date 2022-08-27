#pragma checksum "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2beeb993bcd0f75bbc291d37102c76fc73c100d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Detail), @"mvc.1.0.view", @"/Views/Order/Detail.cshtml")]
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
#line 1 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\_ViewImports.cshtml"
using WebMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\_ViewImports.cshtml"
using WebMvc.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
using WebMvc.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2beeb993bcd0f75bbc291d37102c76fc73c100d6", @"/Views/Order/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82dfb9e8d9c1e15d2e9f7b4d3cf193b2b540299a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebMvc.Models.OrderModels.Order>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
  
    ViewData["Title"] = "Order Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"esh-orders_detail\">\r\n    ");
#nullable restore
#line 9 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
Write(Html.Partial("_Header", new List<Header>() { new Header() { Controller = "Catalog", Text = "Back to catalog" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""container"">
        <section class=""esh-orders_detail-section"">
            <article class=""esh-orders_detail-titles row"">
                <section class=""esh-orders_detail-title col-xs-3"">Order number</section>
                <section class=""esh-orders_detail-title col-xs-3"">Date</section>
                <section class=""esh-orders_detail-title col-xs-3"">Total</section>
                <section class=""esh-orders_detail-title col-xs-3"">Status</section>
            </article>
            <article class=""esh-orders_detail-items row"">
                <section class=""esh-orders_detail-item col-xs-3"">");
#nullable restore
#line 19 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                            Write(Model.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                <section class=\"esh-orders_detail-item col-xs-3\">");
#nullable restore
#line 20 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                            Write(Model.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                <section class=\"esh-orders_detail-item col-xs-3\">$ ");
#nullable restore
#line 21 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                              Write(Math.Round(Model.OrderTotal, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                <section class=\"esh-orders_detail-item col-xs-3\">");
#nullable restore
#line 22 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                            Write(Model.OrderStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</section>
            </article>
        </section>
        <section class=""esh-orders_detail-section"">
            <article class=""esh-orders_detail-titles row"">
                <section class=""esh-orders_detail-title col-xs-12"">Shiping address</section>
            </article>
            <article class=""esh-orders_detail-items row"">
                <section class=""esh-orders_detail-item col-xs-12"">");
#nullable restore
#line 30 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                             Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n            </article>\r\n");
            WriteLiteral("        </section>\r\n        <section class=\"esh-orders_detail-section\">\r\n            <article class=\"esh-orders_detail-titles row\">\r\n                <section class=\"esh-orders_detail-title col-xs-12\">ORDER DETAILS</section>\r\n            </article>\r\n");
#nullable restore
#line 43 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
             for (int i = 0; i < Model.OrderItems.Count; i++)
            {
                var item = Model.OrderItems[i];

#line default
#line hidden
#nullable disable
            WriteLiteral("                <article class=\"esh-orders_detail-items esh-orders_detail-items--border row\">\r\n                    <section class=\"esh-orders_detail-item col-md-4 hidden-md-down\">\r\n                        <img class=\"esh-orders_detail-image\"");
            BeginWriteAttribute("src", " src=\"", 2663, "\"", 2685, 1);
#nullable restore
#line 48 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
WriteAttributeValue("", 2669, item.PictureUrl, 2669, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </section>\r\n                    <section class=\"esh-orders_detail-item esh-orders_detail-item--middle col-xs-4\">");
#nullable restore
#line 50 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                                                               Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                    <section class=\"esh-orders_detail-item esh-orders_detail-item--middle col-xs-1\">$ ");
#nullable restore
#line 51 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                                                                 Write(Math.Round(item.UnitPrice, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                    <section class=\"esh-orders_detail-item esh-orders_detail-item--middle col-xs-1\">");
#nullable restore
#line 52 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                                                               Write(item.Units);

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                    <section class=\"esh-orders_detail-item esh-orders_detail-item--middle col-xs-2\">$ ");
#nullable restore
#line 53 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                                                                 Write(Math.Round(item.Units * item.UnitPrice, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n                </article>\r\n");
#nullable restore
#line 55 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </section>
        <section class=""esh-orders_detail-section esh-orders_detail-section--right"">
            <article class=""esh-orders_detail-titles esh-basket-titles--clean row"">
                <section class=""esh-orders_detail-title col-xs-9""></section>
                <section class=""esh-orders_detail-title col-xs-2"">TOTAL</section>
            </article>
            <article class=""esh-orders_detail-items row"">
                <section class=""esh-orders_detail-item col-xs-9""></section>
                <section class=""esh-orders_detail-item esh-orders_detail-item--mark col-xs-2"">$ ");
#nullable restore
#line 64 "G:\Github\SWC13\JewelsOnContainers\WebMvc\Views\Order\Detail.cshtml"
                                                                                           Write(Math.Round(Model.OrderTotal, 2));

#line default
#line hidden
#nullable disable
            WriteLiteral("</section>\r\n            </article>\r\n        </section>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebMvc.Models.OrderModels.Order> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591