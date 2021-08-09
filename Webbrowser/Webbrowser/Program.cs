using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        private static async Task<string> GetWebsiteContent(string url)
        {
            var uri = new Uri(url);
            var client = new HttpClient();
            var response = await client.GetStringAsync(uri);
            return(response);
        }

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            while (true)
            {
                WebClient client = new WebClient();
                Console.Write("Enter Website to browse: ");
                string RequestURL = Console.ReadLine();

                try
                {
                    var WebsiteContent = await GetWebsiteContent(RequestURL);

                    //Strip the HTML tags
                    WebsiteContent = StripHTML(WebsiteContent);

                    Console.WriteLine(WebsiteContent);
                    Console.WriteLine("Press any button to make a new request: ");
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
