#pragma checksum "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33f7c03082bbe1768343e076729b5d46c22ca4cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_PayingProcess), @"mvc.1.0.view", @"/Views/Pay/PayingProcess.cshtml")]
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
#line 1 "L:\source\repos\WebCosmetic\Views\_ViewImports.cshtml"
using WebCosmetic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "L:\source\repos\WebCosmetic\Views\_ViewImports.cshtml"
using WebCosmetic.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33f7c03082bbe1768343e076729b5d46c22ca4cb", @"/Views/Pay/PayingProcess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e4b1c8c21fd2fa3d367ffc1e0bd3ad27bddbfca", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_PayingProcess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SuccessPayingModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""container-fluid p-2"">
    <div class=""py-1 w-100 alert alert-success"">
        Thanh toán thành công
    </div>
    <div class=""row"">
        <div class=""col-md-6 col-12"">
            <div class=""card"">
                <div class=""card-title"">
                    Thông tin khách hàng
                </div>
                <div class=""card-body"">
                    ");
#nullable restore
#line 14 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._clientInfo._clienName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 15 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._clientInfo._clienName));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 16 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._clientInfo._clientAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 17 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._clientInfo._clientAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 18 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._clientInfo._phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 19 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._clientInfo._phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
                </div>
                <div class=""card-footer text-muted"">
                    Mĩ phẩm SeaBeauty.vn
                </div>
            </div>
        </div>
        <div class=""col-md-6 col-12"">
            <div class=""card"">
                <div class=""card-title"">
                    Thông tin đơn hàng
                </div>
                <div class=""card-body"">
                    ");
#nullable restore
#line 32 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._bill._billCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 33 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._bill._billCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 34 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._bill._transactionCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 35 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._bill._transactionCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 36 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._bill._methodPayment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 37 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._bill._methodPayment));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 38 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._bill._dateSet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 39 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._bill._dateSet));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    ");
#nullable restore
#line 40 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.LabelFor(m => m._bill._totalMoney));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 41 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
               Write(Html.DisplayFor(m => m._bill._totalMoney));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
                </div>
                <div class=""card-footer text-muted"">
                    Mĩ phẩm SeaBeauty.vn
                </div>
            </div>
        </div>
    </div>
    <div class=""container"">
        <p class=""float-right"">
            <a");
            BeginWriteAttribute("href", " href=\"", 2158, "\"", 2197, 1);
#nullable restore
#line 51 "L:\source\repos\WebCosmetic\Views\Pay\PayingProcess.cshtml"
WriteAttributeValue("", 2165, Url.Action("IndexHome", "Home"), 2165, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Mua sắm tiếp>></a>\r\n        </p>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SuccessPayingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
