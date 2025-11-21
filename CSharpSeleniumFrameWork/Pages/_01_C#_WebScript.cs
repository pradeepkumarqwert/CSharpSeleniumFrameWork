using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SeleniumScripts
{
    [TestFixture]
    public class Script1_WebScript
    {
        private IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void PantaloonsSearchTest()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Navigate().GoToUrl("https://www.pantaloons.com");

            Thread.Sleep(2000);

            IWebElement logo = driver.FindElement(By.XPath("//div[@class='nav-header-container']//img[@class='svgIconImg' and @alt='logoIcon']"));
        

            IWebElement searchBar = driver.FindElement(By.XPath("//div[@class='nav-links']//input[@placeholder='Search']"));
            searchBar.Click();
            searchBar.SendKeys("Shirts");
            Thread.Sleep(2000);
            searchBar.SendKeys(Keys.Enter);
            Thread.Sleep(4000);

            IWebElement filterGender = driver.FindElement(By.XPath("//p[text()='Gender']"));
            filterGender.Click();

            IWebElement boysCheckbox = driver.FindElement(By.XPath("//p[text()='Boys']//ancestor::div[contains(@class,'PlpWeb_filter-values')]//input"));
            boysCheckbox.Click();
            Thread.Sleep(3000);

            IWebElement clearBtn = driver.FindElement(By.XPath("//button[@id=':r6:']"));
            clearBtn.Click();

            Console.WriteLine("Test execution completed successfully.");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
