# screenshotmachine-csharp

This demo shows how to call online screenshot machine API using C# programming language.

## Installation
First, you need to create a free/premium account at [www.screenshotmachine.com](https://www.screenshotmachine.com) website. After registration, you will see your customer key in your user profile. Also secret phrase is maintained here. Please, use secret phrase always, when your API calls are called from publicly available websites.  

Set-up your customer key and secret phrase (if needed) in the script:

```csharp
    string customerKey = "PUT_YOUR_CUSTOMER_KEY_HERE";
    string secretPhrase = ""; //leave secret phrase empty, if not needed
```
## Website screenshot API
Set additional options to fulfill your needs: 

```csharp
    var options = new Dictionary<string, string>();
    // mandatory parameter
    options.Add("url", "https://www.google.com");
    // all next parameters are optional, see our API guide for more details
    options.Add("dimension", "1366x768"); // or "1366xfull" for full length screenshot
    options.Add("device", "desktop");
    options.Add("format", "png");
    options.Add("cacheLimit", "0");
    options.Add("delay", "200");
    options.Add("zoom", "100");
```
More info about options can be found in our [Website screenshot API](https://www.screenshotmachine.com/website-screenshot-api.php).  

#### Sample code

```csharp
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

        var apiUrl = sm.GenerateScreenshotApiUrl(options);
        //use final apiUrl where needed
        Console.Write(apiUrl);
    }
}  
```
Generated ```apiUrl```  link can be placed in ```<img>``` tag or used in your business logic later.

If you need to store captured screenshot as an image, just call:

```csharp
    var apiUrl = sm.GenerateScreenshotApiUrl(options);

    //or save screenshot directly
    var output = "output.png";
    new WebClient().DownloadFile(apiUrl, output);
    Console.Write("Screenshot saved as " + output);
```

Captured screenshot will be saved as ```output.png``` file in the current directory.

## Website to PDF API

Set the PDF options: 
```csharp
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
```
More info about options can be found in our [Website to PDF API](https://www.screenshotmachine.com/website-to-pdf-api.php).  
#### Sample code

```csharp
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

        var pdfApiUrl = sm.GeneratePdfApiUrl(options);

        //save PDF file
        var output = "output.pdf";
        new WebClient().DownloadFile(pdfApiUrl, output);
        Console.Write("Pdf saved as " + output);
    }
}  
```
Captured PDF will be saved as ```output.pdf``` file in the current directory.

# License

The MIT License (MIT)    