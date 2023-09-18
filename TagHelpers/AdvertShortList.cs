using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WebCosmetic.TagHelpers
{
    [HtmlTargetElement("AdvertShort")]
    public class AdvertShortList:TagHelper
    {
        public int capacity { get; set; }
        public string[] urlImg { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            this.urlImg = new string[capacity];
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", "d-flex justify-content-between");

            for(int i = 0; i < capacity; i++)
            {
                var bl = new TagBuilder("div");
                var content = new StringBuilder();
                content.Append($@"
                        <a href='#'></a>
                        <img src='{this.urlImg[i]}' alt='Advert image'/>
                ");

                bl.Attributes.Add("style", "width: 30%;");
                bl.AddCssClass("rounded h-100");

                bl.InnerHtml.Append(content.ToString());
                output.Content.AppendHtml(bl);
            }

            
        }
    }
}
