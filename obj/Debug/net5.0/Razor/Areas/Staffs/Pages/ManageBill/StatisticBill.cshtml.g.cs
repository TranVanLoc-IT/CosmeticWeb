#pragma checksum "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f1a80a1deab296bac608efb5dfa870aaeafd182"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Staffs_Pages_ManageBill_StatisticBill), @"mvc.1.0.razor-page", @"/Areas/Staffs/Pages/ManageBill/StatisticBill.cshtml")]
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
#line 1 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\_ViewImports.cshtml"
using WebCosmetic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\_ViewImports.cshtml"
using WebCosmetic.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/thongke-hoadon/")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f1a80a1deab296bac608efb5dfa870aaeafd182", @"/Areas/Staffs/Pages/ManageBill/StatisticBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e4b1c8c21fd2fa3d367ffc1e0bd3ad27bddbfca", @"/Areas/Staffs/Pages/_ViewImports.cshtml")]
    public class Areas_Staffs_Pages_ManageBill_StatisticBill : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "SendReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "~/Views/Shared/_summernotePartial.cshtml", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container-fluid p-2"">
    <div class=""row"">
        <div class=""col-12 col-md-8"">
            <label>Line chart: </label>
            <input type=""radio"" name=""chartOption"" onclick=""UpdateChart(this.value)"" value=""bar"" />

            <label>Pie chart: </label>
            <input type=""radio"" name=""chartOption"" onclick=""UpdateChart(this.value)"" value=""pie"" />
        </div>
        <div id=""chart-container"">
            <canvas id=""ChartBill"" style=""width:100%;max-width:600px""></canvas>
        </div>
        <div class=""col-12 col-md-8"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f1a80a1deab296bac608efb5dfa870aaeafd1826003", async() => {
                WriteLiteral("\r\n                <select id=\"sl_option\" name=\"option\" onclick=\"optionChanges(this.value)\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f1a80a1deab296bac608efb5dfa870aaeafd1826380", async() => {
                    WriteLiteral("\r\n                        Theo tháng\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f1a80a1deab296bac608efb5dfa870aaeafd1827679", async() => {
                    WriteLiteral("\r\n                        Theo năm\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </select>
                <div id=""expand_options"" class=""my-2 mx-2"">
                    <div class=""w-50"">
                        <div class=""month_items float-start"">
                            <label for=""month"">Chọn tháng: </label>
                            <select name=""month"">
");
#nullable restore
#line 33 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                 foreach (var i in Model.monthlabel)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f1a80a1deab296bac608efb5dfa870aaeafd1829614", async() => {
                    WriteLiteral("Tháng ");
#nullable restore
#line 35 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                                        Write(i);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                       WriteLiteral(i);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 36 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </select>\r\n                        </div>\r\n                        <div class=\"year_items float-end\">\r\n                            <label for=\"year\">Chọn năm: </label>\r\n                            <select name=\"year\">\r\n");
#nullable restore
#line 42 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                 foreach (var i in Model.yearlabel)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f1a80a1deab296bac608efb5dfa870aaeafd18212358", async() => {
                    WriteLiteral("Năm ");
#nullable restore
#line 44 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                                      Write(i);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                       WriteLiteral(i);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 45 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            </select>
                        </div>
                        <div class=""clearfix""></div>
                    </div>
                </div>
                <button class=""btn btn-outline-info"" type=""submit"">Chọn</button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row container mx-auto w-75\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f1a80a1deab296bac608efb5dfa870aaeafd18216050", async() => {
                WriteLiteral("\r\n            <textarea id=\"reportMoneyFigure\" name=\"reportContent\"></textarea>\r\n            ");
#nullable restore
#line 60 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
       Write(Html.EditorFor(model => model._report));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <button>Gửi báo cáo</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1f1a80a1deab296bac608efb5dfa870aaeafd18218114", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 65 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = (new SummerNote("reportMoneyFigure",170,true));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</partial>


<!-- Modal Toast Bootstrap 5 -->
<div id=""myToast"" class=""toast position-absolute"" style=""top: 30px;"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"">
    <div class=""toast-header"">
        <strong class=""me-auto fw-bold text-danger"">Thông báo</strong>
        <button type=""button"" class=""btn-close"" data-bs-dismiss=""toast"" aria-label=""Close""></button>
    </div>
    <div class=""toast-body"">
");
#nullable restore
#line 75 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
         if (ViewData["reportState"] != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
       Write(ViewData["reportState"]);

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                                    
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 83 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
     if (ViewData["reportState"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            // Kích hoạt Toast khi có ViewData\r\n            var toast = new bootstrap.Toast(document.getElementById(\'myToast\'));\r\n            toast.show();\r\n        </script>\r\n");
#nullable restore
#line 90 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <script>\r\n        const xValues = ");
#nullable restore
#line 92 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                   Write(Html.Raw(Json.Serialize(Model.xlabel.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        const yValues = ");
#nullable restore
#line 93 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                   Write(Html.Raw(Json.Serialize(Model.ylabel.ToArray())));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        const expandOptions = document.getElementById(""expand_options"");
        const monthOptions = document.querySelector("".month_items"");
        const yearOptions = document.querySelector("".year_items"");
        const optionChanges = (value) => {
            if (value == 1) {
                expandOptions.innerHTML = monthOptions.innerHTML;
            }
            if (value == 2) {
                expandOptions.innerHTML = yearOptions.innerHTML;
            }

        }
        const barColors = [
            ""#b91d47"",
            ""#00aba9"",
            ""#2b5797"",
            ""#e8c3b9"",
            ""#1e7145""
        ];
        // giải quyết khi dữ liệu nhiều hơn số màu => lặp lại random
        if (xValues.length > barColors.length) {
            let loopIndex = barColors.length;
            while (xValues.length > barColors.length) {
                barColors.push(barColors[xValues.length % loopIndex])
            }
        }
        function UpdateChart(value) {
       ");
                WriteLiteral(@"     var canvas = document.getElementById(""ChartBill"");
            var canvasContainer = document.getElementById(""chart-container"");
            if (canvas.innerHTML != null) {
                canvas.remove();
                let create = document.createElement(""canvas"")
                create.id = ""ChartBill"";
                create.style = ""width: 100%; max-width: 600px"";
                canvasContainer.appendChild(create);
            }
            canvas = document.getElementById(""Chart"");
            if (value == ""bar"") {

                new Chart(""ChartBill"", {
                    type: value,
                    data: {
                        labels: xValues,
                        datasets: [{
                            fill: false,
                            lineTension: 0,
                            backgroundColor: barColors,
                            borderColor: ""rgba(0,0,255,0.1)"",
                            data: yValues
                        }]
              ");
                WriteLiteral("      },\r\n                    options: {\r\n                        title: {\r\n                            display: true,\r\n                            text: \"");
#nullable restore
#line 148 "L:\source\repos\WebCosmetic\Areas\Staffs\Pages\ManageBill\StatisticBill.cshtml"
                              Write(Html.Raw(ViewData["ChartTitle"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                        },
                        legend: { display: false },
                        scales: {
                            yAxes: [{ ticks: { min: 6, max: 16 } }],
                        },


                    }
                });
            }
            if (value == ""pie"") {
                new Chart(""ChartBill"", {
                    type: value,
                    data: {
                        labels: xValues,
                        datasets: [{
                            backgroundColor: barColors,
                            data: [55, 49, 44, 24, 15]
                        }]
                    },
                    options: {
                        title: {
                            display: true,
                            text: yValues,
                        }
                    }
                });
            }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebCosmetic.Areas.Staffs.Pages.ManageBill.StatisticBillModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebCosmetic.Areas.Staffs.Pages.ManageBill.StatisticBillModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebCosmetic.Areas.Staffs.Pages.ManageBill.StatisticBillModel>)PageContext?.ViewData;
        public WebCosmetic.Areas.Staffs.Pages.ManageBill.StatisticBillModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
