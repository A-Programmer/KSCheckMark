using System;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KSCheckMark
{
    public class KSCheckMarkTagHelper : TagHelper
    {
        [HtmlTargetElement("i", Attributes = CheckMarkValueAttributeName)]
        public class CheckMarkTagHelper : TagHelper
        {
            private const string CheckMarkValueAttributeName = "ks-value";
            private const string CheckedClassValue = "ks-checked-class";
            private const string UnCheckedClassValue = "ks-unchecked-class";
            private const string TextValue = "ks-text-value";

            /// <summary>
            /// An expression to be evaluated against the current model.
            /// </summary>
            [HtmlAttributeName(CheckMarkValueAttributeName)]
            public bool CheckMarkValue { get; set; }

            [HtmlAttributeName(CheckedClassValue)]
            public string CheckedClassName { get; set; }

            [HtmlAttributeName(UnCheckedClassValue)]
            public string UnCheckedClassName { get; set; }

            [HtmlAttributeName(TextValue)]
            public string TextContent { get; set; }
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
                }

                output.Attributes.SetAttribute("class",classValue);
                output.Content.SetHtmlContent(TextContent);

                base.Process(context, output);
            }
        }
    }
}
