using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Moegirlpedia.WikitextParser
{
    // Sucking WinRT doesn't support XPath! F--k!
    // But we have LINQ! Yay! Java sucks!

    public class HTMLParser
    {
        HtmlDocument _document = null;

        public HtmlDocument Document
        {
            get
            {
                return _document;
            }
            private set
            {
                _document = value;
            }
        }

        public HTMLParser()
        {
        }

        public void Parse(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            Document = doc;
            doc.LoadHtml(html);
        }

        public void StripUselessWhitespace()
        {
            var list = Document.DocumentNode.Descendants().Where(node =>
            {
                // Strip #text with empty content
                if (node.Name != "#text")
                    return false;

                for (int i = 0; i < node.InnerHtml.Length; i++)
                {
                    if (!Char.IsWhiteSpace(node.InnerHtml[i]) && !(node.InnerHtml[i] == '\n') && !(node.InnerHtml[i] == '\r')) return false;
                }
                return true;
            });

            foreach (var node in list.ToArray())
            {
                node.Remove();
            }
        }
    }
}
