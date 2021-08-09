using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webbrowser
{
    class Program
    {
        public static string StripHTML(string input)
        {
            //Remove all HTML tags, by using a regex.
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                WebClient client = new WebClient();

                Console.WriteLine("Enter Website to browse: ");
                string RequestURL = Console.ReadLine();

                try
                {
                    string WebsiteContent = client.DownloadString(RequestURL);
                    Console.WriteLine(StripHTML(WebsiteContent));

                    Console.WriteLine("Press return to make a new request:");
                    Console.ReadKey();
                }
                catch (Exception)
                {

                    Console.WriteLine("Invalid URL");
                }
            }
           

        }
    }
}
