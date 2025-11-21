using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;           
using OpenQA.Selenium.Support.UI;

using System;
using System.IO;
using System.Threading;

class Script2_AndroidChromeRealDeviceWweb
{
    static void Main()
    {
        var options = new AppiumOptions();
        options.AddAdditionalOption("deviceName", "Samsung Galaxy A12");
        options.AddAdditionalOption("platformName", "Android");
        options.AddAdditionalOption("platformVersion", "12");
        options.AddAdditionalOption("browserName", "Chrome");

        string serverUrl = "";

        AndroidDriver driver = new AndroidDriver(new Uri(serverUrl), options);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        void TakeScreenshot(string name)
        {
            string path = $"C:\\SimpleRunScreenshots\\{name}.png";
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path);


        }

        try
        {
            driver.Navigate().GoToUrl("https://www.pantaloons.com/");
            Thread.Sleep(3000);
            TakeScreenshot("01_HomePage");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("div.mobilesearchbox"))).Click();
            TakeScreenshot("02_Click_Search");

            IWebElement search = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Search for products,brands and more...']")));
            search.SendKeys("Shirt");
            TakeScreenshot("03_Entered_Search");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mark[text()='Shirt'])[1]"))).Click();
            TakeScreenshot("04_Result_Clicked");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("span.cartSpriteIcon"))).Click();
            TakeScreenshot("05_Cart_Page");

            Console.WriteLine("Title: " + driver.Title);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            TakeScreenshot("99_Exception");
        }
        finally
        {
            driver.Quit();
        }
    }
}
