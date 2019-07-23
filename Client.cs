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
        // all next parameters are optional, see our API guide for more details
        options.Add("dimension", "1366x768"); // or "1366xfull" for full length screenshot
        options.Add("device", "desktop");
        options.Add("format", "png");
        options.Add("cacheLimit", "0");
        options.Add("delay", "200");

        ScreenshotMachine sm = new ScreenshotMachine(customerKey, secretPhrase);

        var apiUrl = sm.GenerateApiUrl(options);
        //use final apiUrl where needed
        Console.Write(apiUrl);

        //or save screenshot directly
        var output = "output.png";
        new WebClient().DownloadFile(apiUrl, output);
        Console.Write("Screenshot saved as " + output);
    }
}
