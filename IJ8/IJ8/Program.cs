using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IJ8
{
    class Program
    {
        static void Main(string[] args)
        {
            WebParser parser = new WebParser("http://google.com");
            Console.WriteLine(parser.FindContentInTag("head"));
            Console.ReadLine();
        }
    }

    class WebParser : WebClient
    {
        private string _url;

        public WebParser(string url)
        {
            _url = url;
        }

        public string FindContentInTag(string tag)
        {
            string page = DownloadString(_url);
            Regex exp = new Regex($@"(?<=\<({tag})\>)(.*)(?=\<\/({tag})\>)");
            return exp.Match(page).Value;
        }
    }
}
