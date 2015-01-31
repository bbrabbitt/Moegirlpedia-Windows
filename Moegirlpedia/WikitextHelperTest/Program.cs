using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Moegirlpedia.WikitextParser;

namespace WikitextHelperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "WikitextHelperTest.Content.html";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                HTMLParser parser = new HTMLParser();
                parser.Parse(result);
                parser.StripUselessWhitespace();

                WikiDOMParser domParser = new WikiDOMParser();
                domParser.Parse(parser);

            }
        }
    }
}
