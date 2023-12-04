#pragma checksum "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01fb2ca41efbfc5ef617187d03e116a5dcc98cbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_IndexPay), @"mvc.1.0.view", @"/Views/Pay/IndexPay.cshtml")]
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
#line 1 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01fb2ca41efbfc5ef617187d03e116a5dcc98cbc", @"/Views/Pay/IndexPay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e4b1c8c21fd2fa3d367ffc1e0bd3ad27bddbfca", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_IndexPay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayingModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Money", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Banking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "ShipCOD", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
  
    DataTransfer dt = new DataTransfer();

    string user = Context.Session.GetString("user");
    if (user != null)
    {
        var userConverted = JsonConvert.DeserializeObject<CosmeticModel>(user);
        var getCustomerFromLogin = dt.GetCustomerById(userConverted.Id);
        Model._tenkh = getCustomerFromLogin.Tenkh;
        Model._makh = getCustomerFromLogin.Makh;
        Model._phone = getCustomerFromLogin.Sdt;
    }
    else
    {
        // quay về login vì nếu không có session thì chưa login

#line default
#line hidden
#nullable disable
            WriteLiteral("        <script type=\"text/javascript\">\r\n            window.location.href = \"/Authentication/Login\";\r\n        </script>\r\n");
#nullable restore
#line 24 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
    }

    List<ProductCart.DetailsCart> detailsCart = ViewBag.productCart as List<ProductCart.DetailsCart>;
    DataTransfer transfer = new DataTransfer();
    List<SelectListItem> bankSupply = new List<SelectListItem>();
    List<SelectListItem> shippingSupply = new List<SelectListItem>();

    foreach (var i in transfer.GetAllBankingSupply())
    {
        bankSupply.Add(new SelectListItem() { Text = i.Value, Value = i.Key });
    }
    foreach (var i in transfer.GetAllShippingSupply())
    {
        shippingSupply.Add(new SelectListItem() { Text = i.Value, Value = i.Key });
    }
    Model._sanphamMua = new Dictionary<string, int>(detailsCart.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<main role=""main"">
    <div class=""container mt-4"">
        <input type=""hidden"" name=""kh_tendangnhap"">

        <div class=""py-5 text-center"">
            <i class=""fa fa-credit-card fa-4x"" aria-hidden=""true""></i>
            <h2 style=""color:blueviolet;"">Thanh toán</h2>
            <p class=""lead"">Kiểm tra thông tin Khách hàng, thông tin giỏ hàng trước khi đặt hàng.</p>
        </div>

        <div class=""row"">
            <div class=""col-md-4 order-md-2 mb-4"">
                <h4 class=""d-flex justify-content-between align-items-center mb-3"">
                    <span class=""text-muted"">Giỏ hàng</span>
                    <span class=""badge badge-secondary badge-pill"">2</span>
                </h4>
                <ul class=""list-group mb-3"">

");
#nullable restore
#line 59 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                     foreach (ProductCart.DetailsCart product in detailsCart)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item d-flex justify-content-between lh-condensed\">\r\n                            <div>\r\n                                <h6 class=\"my-0\">");
#nullable restore
#line 63 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                                            Write(product.tensp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                <small class=\"text-muted\">");
#nullable restore
#line 64 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                                                     Write(product.soLuongMua);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            </div>\r\n                            <span class=\"text-muted\">");
#nullable restore
#line 66 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                                                 Write(((double)product.giabanmoi * product.soLuongMua).ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </li>\r\n");
#nullable restore
#line 68 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                        Model._sanphamMua.Add(product.masp, product.soLuongMua);
                        Model._totalMoney += (double)product.giabanmoi * product.soLuongMua;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n                <div class=\"total-money\">Tổng thành tiền: <input type=\"number\" class=\"form-control\" name=\"tongTien\" id=\"tongTien\"");
            BeginWriteAttribute("value", " value=\"", 3164, "\"", 3190, 1);
#nullable restore
#line 72 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
WriteAttributeValue("", 3172, Model._totalMoney, 3172, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" contenteditable=""false"" /></div>

                <div class=""input-group"">
                    <input type=""text"" class=""form-control"" placeholder=""Mã khuyến mãi"">
                    <div class=""input-group-append"">
                        <button type=""submit"" class=""btn btn-secondary"">Xác nhận</button>
                    </div>
                </div>

            </div>
            <div class=""col-md-8 order-md-1"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01fb2ca41efbfc5ef617187d03e116a5dcc98cbc10733", async() => {
                WriteLiteral("\r\n                    <h4 class=\"mb-3\">Thông tin khách hàng</h4>\r\n                    <div class=\"row\">\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01fb2ca41efbfc5ef617187d03e116a5dcc98cbc11127", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 86 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        <div class=\"col-md-12\">\r\n                            ");
#nullable restore
#line 88 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.LabelFor(model => model._makh));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 89 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.TextBoxFor(model => model._makh));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-md-12 my-1\">\r\n                            ");
#nullable restore
#line 92 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.LabelFor(model => model._tenkh));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 93 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.TextBoxFor(model => model._tenkh));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-md-12 my-1\">\r\n                            ");
#nullable restore
#line 96 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.LabelFor(model => model._phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 97 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.TextBoxFor(model => model._phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-md-12\">\r\n                            ");
#nullable restore
#line 100 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.LabelFor(model => model._address));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 101 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.TextBoxFor(model => model._address));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-md-12 d-none\">\r\n                            ");
#nullable restore
#line 104 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.LabelFor(model => model._totalMoney));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            ");
#nullable restore
#line 105 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                       Write(Html.TextBoxFor(model => model._totalMoney));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <div class=\"col-md-12 d-none\">\r\n");
#nullable restore
#line 108 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                             foreach (var buy in Model._sanphamMua)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"text\"");
                BeginWriteAttribute("name", " name=\"", 5225, "\"", 5253, 3);
                WriteAttributeValue("", 5232, "_sanphamMua[", 5232, 12, true);
#nullable restore
#line 110 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
WriteAttributeValue("", 5244, buy.Key, 5244, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 5252, "]", 5252, 1, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 5254, "\"", 5272, 1);
#nullable restore
#line 110 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
WriteAttributeValue("", 5262, buy.Value, 5262, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 111 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div>
                    </div>

                    <h4 class=""mb-3"">Hình thức thanh toán</h4>

                    <div class=""d-block my-3"">
                        <select id=""paymentDropdown"" onchange=""javascript:dropDownBankList(this.value)"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01fb2ca41efbfc5ef617187d03e116a5dcc98cbc17676", async() => {
                    WriteLiteral("Tiền mặt");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01fb2ca41efbfc5ef617187d03e116a5dcc98cbc19253", async() => {
                    WriteLiteral("Chuyển khoản");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01fb2ca41efbfc5ef617187d03e116a5dcc98cbc20511", async() => {
                    WriteLiteral("Ship COD");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </select>
                    </div>
                    <div class=""my-3"" id=""dropdownOptions"">

                    </div>

                    <hr class=""mb-4"">
                    <button class=""btn btn-success"" type=""submit"">Đặt hàng</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 83 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
AddHtmlAttributeValue("", 3657, Url.Action("PayingProcess", "Pay"), 3657, 35, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"d-none\">\r\n                    <div class=\"bankOption\">\r\n                        ");
#nullable restore
#line 133 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                   Write(Html.DropDownListFor(model => model._payment, bankSupply));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n\r\n                    <div class=\"shipOption\">\r\n                        ");
#nullable restore
#line 137 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                   Write(Html.DropDownListFor(model => model._payment, shippingSupply));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"fw-bold\">\r\n                            Ngày giao dự kiến: ");
#nullable restore
#line 139 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                                           Write(DateTime.Now.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</main>

<footer class=""footer mt-auto py-3"">
    <div class=""container"">
        <p class=""float-right"">
            <a");
            BeginWriteAttribute("href", " href=\"", 6840, "\"", 6879, 1);
#nullable restore
#line 151 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
WriteAttributeValue("", 6847, Url.Action("IndexHome", "Home"), 6847, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Mua sắm tiếp >></a>
        </p>
    </div>
</footer>
<!-- Modal Toast Bootstrap 5 -->
<div id=""myToast"" class=""toast position-absolute"" style=""top: 30px;"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"">
    <div class=""toast-header"">
        <strong class=""me-auto fw-bold text-danger"">Thông báo</strong>
        <button type=""button"" class=""btn-close"" data-bs-dismiss=""toast"" aria-label=""Close""></button>
    </div>
    <div class=""toast-body"">
");
#nullable restore
#line 162 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
         if (ViewData["payState"] != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 164 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
       Write(ViewData["payState"]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 164 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
                                 
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 170 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
     if (ViewData["payState"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            // Kích hoạt Toast khi có ViewData\r\n            var toast = new bootstrap.Toast(document.getElementById(\'myToast\'));\r\n            toast.show();\r\n        </script>\r\n");
#nullable restore
#line 177 "L:\source\repos\WebCosmetic\Views\Pay\IndexPay.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script>
            var getErrorIfExists = document.getElementById(""AlertResultPay"");
            if (getErrorIfExists.textContent == null) {
                getErrorIfExists.style.display = 'block';
            }

            function dropDownBankList(value) {
                $(document).ready(function () {
                    var dropdown = $('#dropdownOptions');
                    if (value == ""Banking"") {
                        dropdown.html($('.bankOption').html());
                    }
                    else {
                        dropdown.html($('.shipOption').html());
                    }
                });
            }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PayingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
