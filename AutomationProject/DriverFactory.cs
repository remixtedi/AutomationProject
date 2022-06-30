using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationProject;

internal class DriverFactory
{
    public IWebDriver CreateBrowser(string browserName, bool headless = false)
    {
        return browserName switch
        {
            "chrome" => GetChromeDriver(headless),
            "firefox" => GetFirefoxDriver(),
            "edge" => GetEdgeDriver(),
            { } browserValue => throw new NotSupportedException(
                $"{browserValue} is not a supported browser"),
            _ => throw new NotSupportedException("not supported browser: <null>")
        };
    }

    private IWebDriver GetEdgeDriver()
    {
        return new EdgeDriver();
    }

    private IWebDriver GetFirefoxDriver()
    {
        return new FirefoxDriver();
    }

    private IWebDriver GetChromeDriver(bool isHeadless)
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");
        if (isHeadless)
            chromeOptions.AddArgument("headless");

        var chromeDriver = new ChromeDriver(chromeOptions);
        if (isHeadless) chromeDriver.Manage().Window.Size = new Size(1920, 1080);
        return chromeDriver;
    }
}