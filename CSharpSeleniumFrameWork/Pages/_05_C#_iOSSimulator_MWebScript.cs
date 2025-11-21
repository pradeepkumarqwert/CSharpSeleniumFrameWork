using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.iOS;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using System.IO;

class Script5_iOSSimulator_MWeb
{
    static void Main()
    {
        var options = new AppiumOptions();
        options.AddAdditionalOption("deviceName", "Samsung Galaxy A12");
        options.AddAdditionalOption("platformName", "Android");
        options.AddAdditionalOption("platformVersion", "12");
        options.AddAdditionalOption("browserName", "Chrome");

        string serverUrl = "";

        IOSDriver driver = new IOSDriver(new Uri(serverUrl), options);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

        try
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            Thread.Sleep(2000);

            IWebElement search = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("searchInput")));
            search.SendKeys("iPhone");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Console.WriteLine("Title: " + driver.Title);

            driver.ExecuteScript("window.scrollBy(0,500)");
            Thread.Sleep(1000);

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[contains(@href,'Apple')])[1]"))).Click();

            IWebElement heading = wait.Until(ExpectedConditions.ElementIsVisible(By.TagName("h1")));
            Console.WriteLine("Opened Page: " + heading.Text);

            driver.Navigate().Back();
            driver.Navigate().Refresh();
        }
        finally
        {
            driver.Quit();
        }
    }
}
