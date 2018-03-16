using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Thrita.Telegtools
{
    public static class Extensions
    {
        public static string RemoveHtmlTags(this string html)
        {
            return string.IsNullOrWhiteSpace(html) ? html : Regex.Replace(html, "<.*?>", String.Empty);
        }

        public static string RemoveHtmlTags(this string html, string[] acceptableTags)
        {
            if (string.IsNullOrEmpty(html)) return string.Empty;

            var document = new HtmlDocument();
            document.LoadHtml(html);

            //var acceptableTags = new String[] { "strong", "em", "u" };

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (!acceptableTags.Contains(node.Name) && node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }

            return document.DocumentNode.InnerHtml;
        }
    }
}
