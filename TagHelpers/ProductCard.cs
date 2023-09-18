using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WebCosmetic.TagHelpers
{
    [HtmlTargetElement("ProductCard")]
    public class ProductCard:TagHelper
    {
        public string _srcImg { get; set; }
        public string _currentCost { get; set; }
        public string _oldCost { get; set; }
        public int _salePercent { get; set; }
        public string _productName { get; set; }
        public string _shortDescription { get; set; }
        public double _buyed { get; set; }
        public int _reviewPercent { get; set; }
        public ProductCard()
        {
            this._srcImg = "";
            this._reviewPercent = 0;
            this._salePercent = 0;
            this._currentCost = "0";
            this._productName = "Not set";
            this._oldCost = "0";
            this._shortDescription= string.Empty;
            this._buyed = 0;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("class", "card");
            output.Attributes.Add("style", "border-radius: 0 !important;");
            string contentCard = $@"
                 <img src=""{this._srcImg}"" alt=""This image has not loaded"" class=""card-img-top"">
                        <div class=""card-body"">
                            <div class=""card-title"">
                                {this._currentCost} đ
                                <span class=""old-price float-start"">{this._oldCost} đ</span>
                                <span class=""discount float-end p-1 border-1 rounded"">-{this._salePercent}%</span>
                                <span class=""clearfix""></span>
                            </div>
                            <div class=""card-text"">
                                <h6>{this._productName}</h6>
                                <p class=""short-info"">
                                    {this._shortDescription}
                                </p>
                                <span class=""fb-star border-end"" onclick=""starLight(this)"">
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                </span>&nbsp;
                                <span class=""buyed""><i class=""fa fa-shopping-cart""></i>&nbsp;{this._buyed} </span>

                            </div>
                        </div>
                        <div class=""card-footer"">
                            <div class=""progress"">
                                <div style=""width: {this._reviewPercent}%"" class=""progress-bar progress-bar-striped bg-info progress-bar-animated  progress-bar-reverse"" role=""progressbar""
                                    aria-valuenow=""{this._reviewPercent}"" aria-valuemin=""0"" aria-valuemax=""100"">
                                </div>
                                <span>{this._reviewPercent}%</span>
                            </div>
                        </div>
            ";
            output.Content.AppendHtml(contentCard);
        }
    }
}
