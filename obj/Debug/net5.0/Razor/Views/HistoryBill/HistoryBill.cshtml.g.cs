#pragma checksum "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c38cb02801927269a5cfcee175a3a86fc3f5eaf2"
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
#nullable restore
#line 1 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c38cb02801927269a5cfcee175a3a86fc3f5eaf2", @"/Views/HistoryBill/HistoryBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e4b1c8c21fd2fa3d367ffc1e0bd3ad27bddbfca", @"/Views/_ViewImports.cshtml")]
    public class Views_HistoryBill_HistoryBill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
  
    List<HistoryProductBill> products = ViewData["HistoryProduct"] as List<HistoryProductBill>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row container-fluid mx-2 my-2 d-flex justify-content-between flex-wrap"" id=""billBox"">
    
</div>
<div>
</div>
<script>
    const get = document.getElementById(""billBox"");
    $.ajax({
        url: '/api/HistoryAPI/',
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (resdata) {
            var getProducts = ");
#nullable restore
#line 18 "L:\source\repos\WebCosmetic\Views\HistoryBill\HistoryBill.cshtml"
                         Write(Html.Raw(JsonConvert.SerializeObject(products)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
            var text = """";
            for (let i = 0; i < resdata.length; i++) {
                var productText = """";
                for (let j = 0; j < getProducts.length; j++) {
                    if (getProducts[j]._mahd == resdata[i]._bill._billCode) {
                        productText += `
                        <div class=""p-1"">${getProducts[j]._tenSp} x ${getProducts[j]._soluong} - ${getProducts[j]._giaban}</div>`
                    }
                }
                text += `<div class=""card my-1 mx-1 my-1"" style=""width: max-content"">
            <div class=""card-header text-left bg-success"">
                <span>Mã hóa đơn: ${resdata[i]._bill._billCode}</span>
            </div>
            <div class=""card-subtitle text-left p-1"">
                <div>Phương thức: ${resdata[i]._bill._methodPayment}</div>
                <div>Mã giao dịch / giao vận: ${resdata[i]._bill._transactionCode}</div>
            </div>
            <div class=""card-body p-2 text-left"">
         ");
            WriteLiteral(@"       <div>Tên khách hàng: ${resdata[i]._clientInfo._clienName}</div>
                ${productText}

            </div>
            <div class=""footer text-muted"">
                Tổng thanh toán: ${resdata[i]._bill._totalMoney}
            </div>
        </div>`
            }
            get.innerHTML = text;
        },
        error: function () {
            alert(""Some error have occur"");
        }
    });
</script>");
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
