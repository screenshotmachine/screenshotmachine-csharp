using System;
using System.Net;
using System.Collections.Generic;

class ClientPdf
{
    static void Main(string[] args)
    {
        string customerKey = "PUT_YOUR_CUSTOMER_KEY_HERE";
        string secretPhrase = ""; //leave secret phrase empty, if not needed

        var options = new Dictionary<string, string>();
        // mandatory parameter
        options.Add("url", "https://www.google.com");
        // all next parameters are optional, see our website to PDF API guide for more details
        options.Add("paper", "letter");
        options.Add("orientation", "portrait");
        options.Add("media", "print");
        options.Add("bg", "nobg");
        options.Add("delay", "2000");
        options.Add("scale", "50");

        ScreenshotMachine sm = new ScreenshotMachine(customerKey, secretPhrase);

        string pdfApiUrl = sm.GeneratePdfApiUrl(options);

        //save PDF file
        string output = "output.pdf";
        new WebClient().DownloadFile(pdfApiUrl, output);
        Console.Write("Pdf saved as " + output);
    }
}
