#pragma checksum "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15ded10c2f9d5225bd6bec8e8c6f1885c9431dc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HistoryBill_HistoryBill), @"mvc.1.0.view", @"/Views/HistoryBill/HistoryBill.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15ded10c2f9d5225bd6bec8e8c6f1885c9431dc7", @"/Views/HistoryBill/HistoryBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e4b1c8c21fd2fa3d367ffc1e0bd3ad27bddbfca", @"/Views/_ViewImports.cshtml")]
    public class Views_HistoryBill_HistoryBill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SuccessPayingModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
  
    List<HistoryProductBill> products = ViewData["HistoryProduct"] as List<HistoryProductBill>;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row container-fluid mx-2 my-2 d-flex justify-content-between flex-wrap\">\r\n");
#nullable restore
#line 7 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
         foreach (var bill in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card my-1 mx-1 my-1\" style=\"width: max-content\">\r\n                <div class=\"card-header text-left bg-success\">\r\n                    <span>Mã hóa đơn: ");
#nullable restore
#line 11 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                 Write(bill._bill._billCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"card-subtitle text-left p-1\">\r\n                    <div>Phương thức: ");
#nullable restore
#line 14 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                 Write(bill._bill._methodPayment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div>Mã giao dịch / giao vận: ");
#nullable restore
#line 15 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                             Write(bill._bill._transactionCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n                <div class=\"card-body p-2 text-left\">\r\n                    <div>Tên khách hàng: ");
#nullable restore
#line 18 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                    Write(bill._clientInfo._clienName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 19 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                    foreach(var product in products)
                   {
                       if(product._mahd == bill._bill._billCode)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"p-1\">");
#nullable restore
#line 23 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                    Write(product._tenSp);

#line default
#line hidden
#nullable disable
            WriteLiteral(" x ");
#nullable restore
#line 23 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                                      Write(product._soluong);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 23 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                                                          Write(product._giaban);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 24 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"footer text-muted\">\r\n                    Tổng thanh toán: ");
#nullable restore
#line 29 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                                Write(bill._bill._totalMoney);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 32 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SuccessPayingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
