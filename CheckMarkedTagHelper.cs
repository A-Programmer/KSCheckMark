using System;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KSCheckMark
{
    [HtmlTargetElement("i", Attributes = CheckMarkValueAttributeName)]
    public class CheckMarkedTagHelper : TagHelper
    {
        private const string CheckMarkValueAttributeName = "ks-value";
        private const string CheckedClassValue = "ks-checked-class";
        private const string UnCheckedClassValue = "ks-unchecked-class";
        private const string TrueTextValue = "ks-true-text";
        private const string FalseTextValue = "ks-false-text";
        private const string Title = "ks-title";


        [HtmlAttributeName(CheckMarkValueAttributeName)]
        public bool CheckMarkValue { get; set; }

        [HtmlAttributeName(CheckedClassValue)]
        public string CheckedClassName { get; set; }

        [HtmlAttributeName(UnCheckedClassValue)]
        public string UnCheckedClassName { get; set; }

        [HtmlAttributeName(TrueTextValue)]
        public string TrueTextContent { get; set; }
        
        [HtmlAttributeName(FalseTextValue)]
        public string FalseTextContent { get; set; }

        [HtmlAttributeName(Title)]
        public string TitleValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string classValue = "";
            if(CheckMarkValue)
            {
                if(!string.IsNullOrEmpty(CheckedClassName))
                {
                    classValue = CheckedClassName;
                }
                else
                {
                    classValue = "fas fa-check";
                }
                output.Content.SetHtmlContent(TrueTextContent);
            }
            else
            {
                if(!string.IsNullOrEmpty(UnCheckedClassName))
                {
                    classValue = UnCheckedClassName;
                }
                else
                {
                    classValue = "fas fa-times";
                }
                output.Content.SetHtmlContent(FalseTextContent);
            }

            output.Attributes.SetAttribute("class",classValue);
            output.Attributes.SetAttribute("title",TitleValue);

            base.Process(context, output);
        }
    }
}
