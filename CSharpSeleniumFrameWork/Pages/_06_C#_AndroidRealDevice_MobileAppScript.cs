using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using System.IO;

class Script6_AndroidRealDevice_MobileApp
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

        try
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(
               By.XPath("//android.widget.Spinner[@resource-id='com.androidsample.generalstore:id/spinnerCountry']"))).Click();

            driver.FindElement(By.XPath("//android.widget.TextView[@text='Afghanistan']")).Click();

            driver.FindElement(By.Id("com.androidsample.generalstore:id/nameField")).SendKeys("Tester1");
            driver.HideKeyboard();

            driver.FindElement(By.Id("com.androidsample.generalstore:id/radioMale")).Click();

            driver.FindElement(By.Id("com.androidsample.generalstore:id/btnLetsShop")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//android.widget.TextView[@text='Air Jordan 4 Retro']/following-sibling::android.widget.LinearLayout//android.widget.TextView[@resource-id='com.androidsample.generalstore:id/productAddCart']")).Click();

            driver.FindElement(By.Id("com.androidsample.generalstore:id/appbar_btn_cart")).Click();

            Console.WriteLine("Execution Completed Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            driver.Quit();
        }
    }
}
