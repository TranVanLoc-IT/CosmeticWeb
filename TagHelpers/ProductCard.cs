using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using WebCosmetic.Models;
namespace WebCosmetic.TagHelpers
{
    [HtmlTargetElement("ProductCard")]
    public class ProductCard:TagHelper
    {
        public ProductCardModel ProductModel { get; set; } = new ProductCardModel();
        public ProductDataJson data { get; set; } = new ProductDataJson();
        public double giamgia { get; set; }

        public ProductCard()
        {
        }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var toJsonData = JsonConvert.SerializeObject(this.ProductModel);
            double giaban = (double)ProductModel.giaban;
            double giabanmoi = (double)ProductModel.giabanmoi;
            this.giamgia = Math.Ceiling((1 - ( giabanmoi/giaban )) * 100);
            string oldPriceToString = (giaban).ToString("N2").Substring(0, (giaban).ToString("N2").Length - 3);
            string priceToString = (giabanmoi).ToString("N2").Substring(0, (giabanmoi).ToString("N2").Length - 3);
            output.TagName = "a";
            output.Attributes.Add("href", $"/xem-chi-tiet/san-pham?ProductModel={Convert.ToBase64String(Encoding.UTF8.GetBytes(toJsonData))}");
            output.Attributes.Add("class", "card h-100 details_link"+ProductModel.masp);
            output.Attributes.Add("id", "details_link"+ProductModel.masp);
            output.Attributes.Add("style", "border-radius: 0 !important;");
            string contentCard = $@"
                 <img src='./images/SanPham/{data.imgUrl}' alt='This image has not loaded' class='card-img-top h-50'>
                        <div class=""card-body"">
                            <div class=""card-title"">
                                {priceToString} đ 
                                <span class=""old-price float-start"">{oldPriceToString} đ</span>
                                <span class=""discount float-end p-1 border-1 rounded"">-{this.giamgia.ToString()}%</span>
                                <span class=""clearfix""></span>
                            </div>
                            <div class=""card-text"">
                                <h6>{this.ProductModel.tensp}</h6>
                                <p class=""short-info"" style=""font-size: 13px;"">
                                    {data.mota}
                                </p>
                                <span class=""fb-star border-end"" onclick=""starLight(this)"">
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                    <i class=""fa fa-star""></i>
                                </span>&nbsp;
                                <span class=""buyed""><i class=""fa fa-shopping-cart""></i>&nbsp;{this.ProductModel.sldaban} </span>

                            </div>
                        </div>
                        <div class=""card-footer"">
                            <div class=""progress"">
                                <div style=""width: {((float)this.ProductModel.sosao / 1000) * 100}%"" class=""progress-bar progress-bar-striped bg-info progress-bar-animated  progress-bar-reverse"" role=""progressbar""
                                    aria-valuenow=""{this.ProductModel.sosao}"" aria-valuemin=""0"" aria-valuemax=""700"">
                                </div>
                                <span>{Math.Floor(((float)this.ProductModel.sosao / 1000)*100)}%</span>
                            </div>
                        </div>
            ";
            output.Content.AppendHtml(contentCard);
            base.Process(context, output);
        }
    }
}
