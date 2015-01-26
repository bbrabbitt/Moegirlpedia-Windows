using System;
using System.Linq;
using System.IO;
//using HtmlAgilityPack;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moegirlpedia.WikitextHelper;

namespace UnitTestWikitextHelper
{
    [TestClass]
    public class TestHTMLParser
    {
        System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
     
        HTMLParser _parser = new HTMLParser();
        string _htmlContent;

        public TestHTMLParser()
        {
            using (Stream stream = assembly.GetManifestResourceStream("UnitTestWikitextHelper.HTMLContent.html"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    _htmlContent = reader.ReadToEnd();
                }
            }

            _parser.Parse(_htmlContent);
        }

        [TestMethod]
        public void H2Nodes()
        {

        }
    }
}
