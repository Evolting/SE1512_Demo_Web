using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Tags
{
    [HtmlTargetElement("pager")]
    public class PagerTagHelper : TagHelper
    {
        public int TotalPage { get; set; }
        public string Url { get; set; }
        public int CurrentPage { get; set; }
        public string ActiveClass { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (TotalPage <= 1) return;
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "something");
            for (int i = 1; i <= TotalPage; i++)
                if (i == CurrentPage)
                    output.Content.AppendHtml($"<input type='submit' name='pageNumber' class='{ActiveClass}' value={i} />");
                else
                    output.Content.AppendHtml($"<input type='submit' name='pageNumber' value={i} />");
        }
    }
}
