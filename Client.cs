using System;
using System.Net;
using System.Collections.Generic;

class Client
{
    static void Main(string[] args)
    {
        string customerKey = "PUT_YOUR_CUSTOMER_KEY_HERE";
        string secretPhrase = ""; //leave secret phrase empty, if not needed

        var options = new Dictionary<string, string>();
        // mandatory parameter
        options.Add("url", "https://www.google.com");
        // all next parameters are optional, see our webtite screenshot API guide for more details
        options.Add("dimension", "1366x768"); // or "1366xfull" for full length screenshot
        options.Add("device", "desktop");
        options.Add("format", "png");
        options.Add("cacheLimit", "0");
        options.Add("delay", "200");
        options.Add("zoom", "100");

        ScreenshotMachine sm = new ScreenshotMachine(customerKey, secretPhrase);

        string apiUrl = sm.GenerateScreenshotApiUrl(options);
        //use final apiUrl where needed
        Console.WriteLine(apiUrl);

        //or save screenshot directly
        string output = "output.png";
        new WebClient().DownloadFile(apiUrl, output);
        Console.WriteLine("Screenshot saved as " + output);
    }
}
