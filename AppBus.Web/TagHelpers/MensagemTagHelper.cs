using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AppBus.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string? Mensagem { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            if (!string.IsNullOrEmpty(Mensagem))
            {
                output.Attributes.SetAttribute("class", "alert alert-dismissible alert-primary");
                output.Content.SetContent(Mensagem);
            }

        }
    }

}

