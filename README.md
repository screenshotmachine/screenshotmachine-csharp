# screenshotmachine-csharp

This demo shows how to call online screenshot machine API using C# programming language.

## Installation
First, you need to create a free/premium account at [www.screenshotmachine.com](https://www.screenshotmachine.com) website. After registration, you will see your customer key in your user profile. Also secret phrase is maintained here. Please, use secret phrase always, when your API calls are called from publicly available websites.  

Set-up your customer key and secret phrase (if needed) in the script:

```csharp
    string customerKey = "PUT_YOUR_CUSTOMER_KEY_HERE";
    string secretPhrase = ""; //leave secret phrase empty, if not needed
```

Set other options to fulfill your needs: 

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
```
More info about options can be found in our [API guide](https://www.screenshotmachine.com/apiguide.php).  

 Sample code
-----

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
    }
}  
```
Generated ```apiUrl```  link can be placed in ```<img>``` tag or used in your business logic later.

If you need to store captured screenshot as an image, just call:

```csharp
    var apiUrl = sm.GenerateApiUrl(options);

    //or save screenshot directly
    var output = "output.png";
    new WebClient().DownloadFile(apiUrl, output);
    Console.Write("Screenshot saved as " + output);
```

Captured screenshot will be saved as ```output.png``` file in current directory.

# License

The MIT License (MIT)    