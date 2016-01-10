using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Mvc.ViewFeatures;
using System;
using System.IO;
using Microsoft.Extensions.WebEncoders;

namespace TLAuction5.HtmlExtensions
{
    public static class ListControlExtensions
    {
        public static HtmlString CheckBoxList(this IHtmlHelper htmlHelper, string name,
                MultiSelectList listInfos)
        {
            return CheckBoxList(htmlHelper, name, listInfos, 0);
        }
        public static HtmlString CheckBoxList(this IHtmlHelper htmlHelper, string name,
                MultiSelectList listInfos, int iPosition)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("This parameter cannot be null or empty!", "name");
            }
            if (listInfos == null)
            {
                throw new ArgumentException("This parameter cannot be null!", "listInfos");
            }
            //if (listInfos.Count<SelectListItem>() < 1)
            //{
            //    throw new ArgumentException("The count must be greater than 0!", "listInfos");
            //}
            List<string> selectedValues = (List<string>)listInfos.SelectedValues;
            List<TagBuilder> lsTagBuilders = new List<TagBuilder>();

            int lineNumber = 0;
            foreach (SelectListItem info in listInfos)
            {
                lineNumber++;
                TagBuilder builder = new TagBuilder("input");
                if (selectedValues.Contains(info.Value))
                {
                    builder.MergeAttribute("checked", "checked");
                }
                builder.MergeAttribute("type", "checkbox");
                builder.MergeAttribute("name", name);
                builder.MergeAttribute("value", info.Value);
                builder.InnerHtml.AppendHtml(info.Text);
                if (iPosition == 0)
                {
                    builder.InnerHtml.AppendHtml("<br />"); ;
                }
                lsTagBuilders.Add(builder);

            }
            using (var writer = new StringWriter())
            {
                foreach (TagBuilder oTagBuilder in lsTagBuilders)
                    oTagBuilder.WriteTo(writer, new HtmlEncoder());


                return new HtmlString(writer.ToString());
            }
        }


    }
}
